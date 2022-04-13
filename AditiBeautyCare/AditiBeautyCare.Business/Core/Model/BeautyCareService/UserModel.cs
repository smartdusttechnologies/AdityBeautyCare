using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    public class UserModel : Entity
    {
        public UserModel(string emailId)
        {
            EmailId = emailId;
        }

        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string EmailId { get; set; }
    }
}
