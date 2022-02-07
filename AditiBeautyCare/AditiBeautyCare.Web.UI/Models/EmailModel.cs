using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AditiBeautyCare.Web.UI.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string EmailTo { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
