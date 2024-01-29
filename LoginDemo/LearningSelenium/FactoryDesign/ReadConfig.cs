using Newtonsoft.Json;

namespace LearningSelenium.FactoryDesign
{
    public class ReadConfig
    {
        public string baseUrl {  get; set; }    
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postal { get; set; }

        public static ReadConfig GetReadConfig(string filepath)
        {
            string json=File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<ReadConfig>(json);
        }

    }
}
