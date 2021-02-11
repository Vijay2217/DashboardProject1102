using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Models
{
    interface IUserDAO:IDAO<RegisterUserViewModel>
    {
        Boolean Authenticate(LoginViewModel user);
    }
}
