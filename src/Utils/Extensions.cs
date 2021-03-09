using System.Collections.Generic;

namespace AutoClicker.Utils
{
    public static class Extensions
    {
        public static T Pop<T>(this List<T> list)
        {
            if (list.Count > 0)
            {
                var item = list[0];

                list.RemoveAt(0);

                return item;
            }
            else return default(T);
        }
    }
}
