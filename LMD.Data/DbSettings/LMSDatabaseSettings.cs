using LMS.Data.DbSettings.Interface;

namespace LMS.Data.DbSettings
{
    public class LMSDatabaseSettings: ILMSDatabaseSettings
    {
        public string LMSCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string LMSCourse { get; set; }

    }
}
