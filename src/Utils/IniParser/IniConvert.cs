using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace AutoClicker.Utils.IniParser
{
    public class IniConvert
    {
        private static BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public static T FromTo<T>(string iniContent) where T: class
        {
            var type = typeof(T);

            var properties = type.GetProperties(Flags).GetMemberInfos();
            var fields = type.GetFields(Flags).GetMemberInfos();

            var instance = FormatterServices.GetUninitializedObject(type);

            var elements = iniContent.IniSplit();

            for (int i = 0; i < elements.Length; i += 2)
            {
                var key = elements[i];
                var iniValue = elements[i + 1];

                if (properties.TryGetValue(key, out PropertyInfo property))
                {
                    property.SetValue(instance, DeserializableObject(property.PropertyType, iniValue), null);
                }
                else if (fields.TryGetValue(key, out FieldInfo field))
                {
                    field.SetValue(instance, DeserializableObject(field.FieldType, iniValue));
                }
            }

            return (T)instance;
        }

        public static string ToFrom(object obj)
        {
            var type = obj.GetType();

            var writer = new StringBuilder();

            var properties = type.GetProperties(Flags);
            var fields = type.GetFields(Flags);

            foreach (var property in properties)
            {
                if (property.IsSerializable())
                {
                    var value = property.GetValue(obj, null);

                    var iniValue = SerializableObject(value);

                    writer.AppendValue(property.Name, iniValue);
                }
            }

            foreach (var field in fields)
            {
                if (field.IsSerializable())
                {
                    var value = field.GetValue(obj);

                    var iniValue = SerializableObject(value);

                    writer.AppendValue(field.Name, iniValue);
                }
            }

            return writer.ToString();
        }

        private static string SerializableObject(object obj)
        {
            var type = obj.GetType();

            if (type == typeof(string))
            {
                return string.Format("\"{0}\"", obj.ToString());
            }
            else if (type.IsPrimitive)
            {
                return obj.ToString();
            }
            else if (type == typeof(Point))
            {
                var point = (Point)obj;

                return string.Format("{0},{1}", point.X, point.Y);
            }
            else
            {
                throw new SerializationException("Такой тип переменной не поддерживаеться: " + type.ToString());
            }
        }

        private static object DeserializableObject(Type type, string iniValue)
        {
            if (type == typeof(string))
            {
                var text = iniValue.Substring(1, iniValue.Length - 2);

                return text;
            }
            else if (type.IsPrimitive)
            {
                return Convert.ChangeType(iniValue, type);
            }
            else if (type == typeof(Point))
            {
                var pointLines = iniValue.Split(',');

                var x = int.Parse(pointLines[0]);
                var y = int.Parse(pointLines[1]);

                return new Point(x, y);
            }
            else
            {
                throw new SerializationException("Такой тип переменной не поддерживаеться: " + type.ToString());
            }
        }
    }    
}
