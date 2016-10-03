using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.UserService
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);
    }
}
