using AutoClicker.Data.Mouse;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AutoClicker.Data.Click
{
    public class Datas
    {
        public const string SaveFolder = "Save";

        public List<ClickData> ClickDatas { get; set; }

        public Datas()
        {
            ClickDatas = new List<ClickData>();
        }

        public Datas(ClickData[] clickDatas) : this()
        {
            ClickDatas.AddRange(clickDatas);
        }

        public void AddData(int interval, EMouse mouse, CursorPosition cursorPosition)
        {
            var count = ClickDatas.Count;

            if (count > 0)
            {
                var lastData = ClickDatas[count - 1];

                if (lastData.CursorPosition == cursorPosition)
                {
                    return;
                }
            }

            ClickDatas.Add(new ClickData(interval, mouse, cursorPosition));
        }

        public ClickData GetClickData()
        {
            var click = this.ClickDatas[0];

            this.ClickDatas.RemoveAt(0);

            return click;
        }

        public void Save()
        {
            string path = $"Save/AutoClicker_{MainForm.Random.Next(1000, 9999)}.json";

            string json = JsonConvert.SerializeObject(this);

            using (var writer = new StreamWriter(path, false))
            {
                writer.WriteLine(json);
            }
        }

        public static Datas Open(string filename)
        {
            string json = string.Empty;

            using (var reader = new StreamReader(filename))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Datas>(json);
        }
    }
}