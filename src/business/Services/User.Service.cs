using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class UserService : IUserService
    {
        public string CurrentUser => "System";
    }
}
