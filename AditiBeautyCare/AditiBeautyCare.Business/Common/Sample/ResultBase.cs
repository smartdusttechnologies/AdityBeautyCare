using System;
using System.Collections.Generic;
using System.Text;
using AditiBeautyCare.Business.Common.Sample;

namespace AditiBeautyCare.Business.Common.Sample
{
    public class ResultBase
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the validation messages.
        /// </summary>
        /// <value>The validation messages.</value>
        public IList<ValidationMessage> ValidationMessages { get; set; }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Determines whether this instance has any failure Validation Messages
        /// </summary>
        protected bool HasFailureMessages()
        {
            return this.HasFailureValidationMessages();
        }

        #endregion


    }
}
