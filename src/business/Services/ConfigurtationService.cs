using Business.DB;
using Business.DB.Dbo;
using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ConfigurtationService : IConfigurtationService
    {
        private ImageOrganizerContex _context;

        ConfigurtationService(ImageOrganizerContex context)
        {
            _context = context;
        }
        public T GetConfigurtion<T>(EConfigurationKey key)
        {

            throw new NotImplementedException();
        }
    }
}
