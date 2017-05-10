using System.Collections.Generic;
using HentovWebsite.Models.Entity.Users;
using Microsoft.AspNet.Identity;

namespace HentovWebsite.Models.View.ManageAccount
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public WebsiteUser User { get; set; }
    }
}