using LMS.DbSettings.Interface;

namespace LMS.DbSettings
{
    public class LMSDatabaseSettings: ILMSDatabaseSettings
    {
        public string LMSCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        
        public string UserCollectionName { get; set; }
    }
}
