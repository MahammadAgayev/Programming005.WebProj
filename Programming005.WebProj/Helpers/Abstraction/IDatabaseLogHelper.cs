using Programming005.WebProj.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming005.WebProj.Helpers.Abstraction
{
    public interface IDatabaseLogHelper
    {
        public void AddOpertionLog(string operation);
    }
}
