using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Data
{
    public class UserIdentity : IdentityUser
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
    }
}
