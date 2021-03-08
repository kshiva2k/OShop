using System;

namespace OShop.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Loginname { get; set; }
        public string Mobileno { get; set; }
        public string Email { get; set; }
        public int Roleid { get; set; }
        public int Agencyid { get; set; }

        public string RoleName { get; set; }

        public string JavascriptFunction { get; set; }
    }

    public class SelectionItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public bool Selected { get; set; }
    }
}
