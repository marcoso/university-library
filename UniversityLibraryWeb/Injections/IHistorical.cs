using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibraryWeb.Models;

namespace UniversityLibraryWeb.Injections
{
    /// <summary>
    /// Interface provided for dependency injection usage for operations that query Books Historicals
    /// </summary>
    public interface IHistorical
    {
        DemandModel GetDemand(string id);
        IEnumerable<DemandModel> GetDemands();        
        bool CancelDemand(string id);
    }
}
