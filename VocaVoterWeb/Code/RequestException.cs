using System;

namespace VocaVoter.Web.Code {

	/// <summary>
	/// An exception thrown by the web request
	/// </summary>
	public class RequestException : Exception {

		/// <summary>
		/// Initializes exception with a message.
		/// </summary>
		/// <param name="message">Error message. Can be null or empty.</param>
		public RequestException(string message)
			: base(message) {

		}

	}

}