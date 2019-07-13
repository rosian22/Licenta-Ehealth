using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class RegisterViewModelAdditons
    {
        public Guid Id { get; set; }

        public UserType userType { get; set; }

        public string PhoneNumber { get; set; }
    }
}
