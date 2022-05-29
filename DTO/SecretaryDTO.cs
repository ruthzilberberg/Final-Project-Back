using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class SecretaryDTO
    {
        public int SecretaryId { get; set; }
        public string SecretaryFirstName { get; set; }
        public string SecretaryLastName { get; set; }
        public string SecretaryTz { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Nullable<int> Permission { get; set; }
        public string Password { get; set; }
    }
}
