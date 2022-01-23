using System;
using System.Collections.Generic;
using System.Text;
using AditiBeautyCare.Business.Common.Sample;
namespace AditiBeautyCare.Business.Common.Sample
{
    public class RequestResult<T> : ResultBase
    {
        #region public Properties
        public T RequestedObject { get; set; }

        public bool IsSuccessful
        {
            get
            {
                bool successful = !HasFailureMessages();
                if(successful && RequestedObject == null)
                {
                    successful = false;
                }
                return successful;
            }
        }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
		/// </summary>
		public RequestResult()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="requestedObject">The requested object.</param>
		public RequestResult(T requestedObject) : this()
		{
			RequestedObject = requestedObject;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="validationMessages">The validation messages.</param>
		public RequestResult(IList<ValidationMessage> validationMessages)
			: this()
		{
			ValidationMessages = validationMessages;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="requestedObject">The requested object.</param>
		/// <param name="validationMessages">The validation messages.</param>
		public RequestResult(T requestedObject, IList<ValidationMessage> validationMessages)
			: this()
		{
			RequestedObject = requestedObject;
			ValidationMessages = validationMessages;
		}

		#endregion
	}
}
