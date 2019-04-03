using Business.DB.Dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB
{
    public interface IConfigurationRepository : IRepository<Configuration, EConfigurationKey>
    {
    }
}
