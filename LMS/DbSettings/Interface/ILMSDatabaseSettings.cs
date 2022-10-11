using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.DbSettings.Interface
{
    public interface ILMSDatabaseSettings
    {
        public string LMSCollectionName { get; set; }        
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string LMSCourse { get; set; }

    }
}
