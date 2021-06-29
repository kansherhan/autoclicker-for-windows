using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutoClicker.Utils.IniParser
{
    public static class Extensions
    {
        public static string[] IniSplit(this string content)
        {
			var lines = content.Split('\n');
			var elements = new List<string>();

			foreach (var line in lines)
			{
				var parts = line.Split('=');

				if (parts.Length >= 2)
				{
					elements.Add(parts[0]);
					elements.Add(parts[1]);
				}
			}

			return elements.ToArray();
        }

        public static bool IsSerializable<T>(this T member) where T: MemberInfo
        {
            return member.IsDefined(typeof(IniIgnorePropertyAttribute), true) == false;
        }

        public static Dictionary<string, T> GetMemberInfos<T>(this T[] members) where T: MemberInfo
        {
            var dictionary = new Dictionary<string, T>();

            foreach (var member in members)
            {
                if (member.IsSerializable())
                {
                    dictionary.Add(member.Name, member);
                }
            }

            return dictionary;
        }

        public static void AppendValue(this StringBuilder writer, string name, string value)
        {
            writer.AppendFormat("{0}={1}\n", name, value);
        }
    }
}