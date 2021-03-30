using System.IO;
using System.Collections.Generic;
using AutoClicker.Utils.Json;

namespace AutoClicker.Data
{
    public class ClickList
    {
        public List<Click> Clicks { get; }

        public int Count => Clicks.Count;

        public Click this[int index]
        {
            get => Clicks[index];
            set => Clicks[index] = value;
        }

        public ClickList()
        {
            Clicks = new List<Click>();
        }

        public ClickList(Click[] clickDatas)
        {
            Clicks = new List<Click>(clickDatas);
        }

        public void Save(string path)
        {
            if (Clicks.Count > 0)
            {
                var json = JsonConvert.ToJson(Clicks);

                using (var writer = new StreamWriter(path, false))
                {
                    writer.Write(json);
                }
            }
        }

        public static ClickList Open(string path)
        {
            var json = string.Empty;

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            var clicks = JsonConvert.FromJson<Click[]>(json);

            return new ClickList(clicks);
        }
    }
}
