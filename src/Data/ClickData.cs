using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AutoClicker.Data
{
    public class ClickData
    {
        public const string SaveFolderPath = "Data";

        public List<Click> Clicks { get; set; }

        public ClickData()
        {
            Clicks = new List<Click>();
        }

        public ClickData(Click[] clickDatas) : this()
        {
            Clicks.AddRange(clickDatas);
        }

        public void AddData(int interval, MouseType mouse, Point cursorPosition)
        {
            if (mouse != MouseType.None)
            {
                Clicks.Add(new Click(interval, mouse, cursorPosition));
            }
        }

        public Click Pop()
        {
            var click = Clicks[0];

            Clicks.RemoveAt(0);

            return click;
        }

        public void Save()
        {
            var today = System.DateTime.Now.ToString("yyyy_MM_d_hh_mm_ss");

            var path = $"{SaveFolderPath}/AutoClicker_{today}.json";

            var json = JsonConvert.SerializeObject(this);

            using (var writer = new StreamWriter(path, false))
            {
                writer.WriteLine(json);
            }
        }

        public static ClickData Open(string filename)
        {
            var json = string.Empty;

            using (var reader = new StreamReader(filename))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ClickData>(json);
        }
    }
}
