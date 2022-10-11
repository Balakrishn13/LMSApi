namespace LMS.Data.DbSettings.Interface
{
    public interface ILMSDatabaseSettings
    {
        public string LMSCollectionName { get; set; }        
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string LMSCourse { get; set; }

    }
}
