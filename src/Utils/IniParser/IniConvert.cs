using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace AutoClicker.Utils.IniParser
{
    public static class IniConvert
    {
        private static BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public static object FromTo(Type type, string iniContent, char seporator = '\n')
        {
            if (!type.IsClass) throw new ArgumentException("Тип должен быть классом");
            
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

            return instance;
        }
        
        public static T FromTo<T>(string iniContent, char seporator = '\n') where T: class
        {
            var type = typeof(T);
            
            return (T)FromTo(type, iniContent, seporator);
        }

        public static string ToFrom(object obj, char seporator = '\n')
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

                    writer.AppendValue(property.Name, iniValue, seporator);
                }
            }

            foreach (var field in fields)
            {
                if (field.IsSerializable())
                {
                    var value = field.GetValue(obj);

                    var iniValue = SerializableObject(value);

                    writer.AppendValue(field.Name, iniValue, seporator);
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
            else if (type == typeof(Color))
            {
                var color = (Color)obj;

                return string.Format("{0},{1},{2},{4}", color.A, color.R, color.G, color.B);
            }
            else if (type.IsArray)
            {
                var arrayType = type.GetElementType();
                var writer = new StringBuilder();
                var array = (Array)obj;
                
                if (arrayType.IsClass)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        writer.Append(IniConvert.ToFrom(array.GetValue(i), '+'));
                        
                        if (i + 1 < array.Length) writer.Append(";");
                    }
                    
                    return writer.ToString();
                }
                else if (arrayType.IsPrimitive || arrayType == typeof(string))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        writer.Append(SerializableObject(array.GetValue(i)));
                        
                        if (i + 1 < array.Length) writer.Append(";");
                    }
                    
                    return writer.ToString();
                }
            }
            
            throw new SerializationException("Такой тип переменной не поддерживаеться: " + type.ToString());
        }

        private static object DeserializableObject(Type type, string iniValue)
        {
            if (type == typeof(string))
            {
                return iniValue.Substring(1, iniValue.Length - 2);
            }
            else if (type.IsPrimitive)
            {
                return Convert.ChangeType(iniValue, type);
            }
            else if (type == typeof(Point))
            {
                var pointParams = iniValue.Split(',');

                if (pointParams.Length >= 2)
                {
                    var x = int.Parse(pointParams[0]);
                    var y = int.Parse(pointParams[1]);

                    return new Point(x, y);
                }
                else
                {
                    throw new ArgumentException("Количество аргументов не достаточно: " + type.ToString());
                }
            }
            else if (type == typeof(Color))
            {
                var colorParams = iniValue.Split(',');

                if (colorParams.Length >= 4)
                {
                    var a = byte.Parse(colorParams[0]);
                    var r = byte.Parse(colorParams[1]);
                    var g = byte.Parse(colorParams[2]);
                    var b = byte.Parse(colorParams[3]);

                    return Color.FromArgb(a, r, g, b);
                }
                else
                {
                    throw new ArgumentException("Количество аргументов не достаточно: " + type.ToString());
                }
            }
            else if (type.IsArray)
            {
                var arrayType = type.GetElementType();
                var iniArray = iniValue.IniArraySplit();
                var array = Array.CreateInstance(arrayType, iniArray.Length);
                
                if (type.IsClass)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array.SetValue(FromTo(arrayType, iniArray[i], '+'), i);
                    }
                }
                else if (type.IsPrimitive)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array.SetValue(DeserializableObject(arrayType, iniArray[i]), i);
                    }
                    
                    return array;
                }
            }
            
            throw new SerializationException("Такой тип переменной не поддерживаеться: " + type.ToString());
        }
    }
}
