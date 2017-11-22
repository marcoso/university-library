using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Injections
{
    public interface IRegister
    {
        bool RegisterMember(string user, string password);
        UserModel LoginMember(string user, string password);
    }
}
