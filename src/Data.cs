using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AutoClicker
{
    public class Data
    {
        public int? LastInterval { get; set; } = null;

        public List<ClickData> ClickDatas { get; set; }

        [JsonIgnore]
        public int IntervalIndex { get; set; }

        public static Random random = new Random();

        public Data() { }

        public Data(ClickData[] clickDatas)
        {
            ClickDatas = new List<ClickData>();

            ClickDatas.AddRange(clickDatas);
            LastInterval = clickDatas.Last().Milisecond;
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
            string path = $"{MainForm.SaveFolder}/AutoClicker_{random.Next(1000, 9999)}.json";

            string json = JsonConvert.SerializeObject(data);
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
