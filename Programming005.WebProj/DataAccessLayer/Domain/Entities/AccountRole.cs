using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming005.WebProj.DataAccessLayer.Domain.Entities
{
    public class AccountRole
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }

        public Account Account { get; set; }
        public Role Role { get; set; }
    }
}
