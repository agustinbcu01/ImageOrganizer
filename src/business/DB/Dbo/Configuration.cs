using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB.Dbo
{
    public enum EConfigurationKey { rootPath, timeOut, dropLocation }
    public class Configuration : IEntity<EConfigurationKey>
    {
        public EConfigurationKey Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
