using Newtonsoft.Json;

namespace LearningSelenium.FactoryDesign
{
    public class ReadTestDataConfig
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postal { get; set; }

        public static ReadTestDataConfig GetTestDataConfig(string filepath)
        {
            string json=File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<ReadTestDataConfig>(json);
        }

    }
}
