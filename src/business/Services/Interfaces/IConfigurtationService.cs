using Business.DB.Dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Interfaces
{
    public interface IConfigurtationService
    {
        T GetConfigurtion<T>(EConfigurationKey key);
    }
}
