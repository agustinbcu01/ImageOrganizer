using Business.DB.Dbo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB
{
    public class ConfigurationRepository : RepositoryBase<Configuration, EConfigurationKey>, IConfigurationRepository
    {
        public ConfigurationRepository(DbContext context) : base(context)
        {
        }
    }
}
