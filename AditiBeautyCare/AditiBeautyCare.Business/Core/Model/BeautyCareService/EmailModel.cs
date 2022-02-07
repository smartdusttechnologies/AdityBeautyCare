using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    public class EmailModel:Entity
    {
        public string EmailTo { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

