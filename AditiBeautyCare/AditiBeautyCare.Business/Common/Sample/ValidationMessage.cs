using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Common.Sample
{
     public class ValidationMessage
    {
        public string Reason { get; set; }

        public virtual ValidationSeverity Severity { get; set; }
        public string MessageKey { get; set; }

        public string Description { get; set; }
    }
    public enum ValidationSeverity
    {
        None,
        Information,
        Warning,
        Error,
        Critical,
    }
}
