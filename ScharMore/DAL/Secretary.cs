//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Secretary
    {
        public int IdSecretary { get; set; }
        public string SecretaryFirstName { get; set; }
        public string SecretaryLastName { get; set; }
        public string SecretaryTz { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }
}
