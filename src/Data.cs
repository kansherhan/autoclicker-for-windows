using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoCliker
{
    public class Data
    {
        public int Interval;
        public int IntervalCount;

        public List<ClickData> ClickDatas;

        [JsonIgnore]
        public int IntervalIndex;

        public static Random random = new Random();

        public Data() { }

        public Data(int interval)
        {
            IntervalCount = IntervalIndex = 0;
            Interval = interval;

            ClickDatas = new List<ClickData>();
        }

        public Data(int interval, ClickData[] clickDatas) : this(interval)
        {
            ClickDatas.AddRange(clickDatas);
            IntervalCount = ClickDatas.Last().Tick;

            Interval = interval;
        }

        public void Ticked()
        {
            IntervalIndex++;
        }

        public void AddData(Mouse mouse, CursorPosition cursorPosition)
        {
            if (ClickDatas.Count > 0)
            {
                if (ClickDatas.Last().CursorPosition == cursorPosition)
                {
                    return;
                }
            }

            ClickDatas.Add(new ClickData(IntervalIndex, mouse, cursorPosition));
        }

        public static void Save(ref Data data)
        {
            string path = $"Save/AutoClicker_{random.Next(1000, 9999)}.json";

            data.IntervalCount = data.ClickDatas.Last().Tick;

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            data = null;

            using (var writer = new StreamWriter(path, false))
            {
                writer.WriteLine(json);
            }
        }

        public static Data Open(string path)
        {
            string json = string.Empty;

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Data>(json);
        }
    }
}
