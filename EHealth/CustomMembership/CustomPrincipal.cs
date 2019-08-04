using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomMembership
{
    public class CustomPrincipal : IPrincipal
    {
        protected readonly IIdentity mIdentity;

        public CustomPrincipal(IIdentity identity)
        {
            mIdentity = identity;
        }

        public List<string> RoleIds { get; set; }

        public IIdentity Identity => mIdentity;

        public bool IsInRole(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || RoleIds == null || RoleIds.Count == 0)
            {
                return false;
            }

            return RoleIds.Any(customRoleId => string.Equals(customRoleId, roleId, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
