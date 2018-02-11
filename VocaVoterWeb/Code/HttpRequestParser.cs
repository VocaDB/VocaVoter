using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VocaVoter.Web.Code {

	/// <summary>
	/// ASP.NET HTTP request parser.
	/// </summary>
	public class HttpRequestParser {

		private readonly HttpRequest request;

		/// <summary>
		/// Initializes parser object based on existing request.
		/// </summary>
		/// <param name="request">HTTP request object. Cannot be null.</param>
		public HttpRequestParser(HttpRequest request) {

			if (request == null)
				throw new ArgumentNullException("request");

			this.request = request;

		}

		/// <summary>
		/// Gets an boolean from the web request.
		/// </summary>
		/// <param name="paramName">Parameter name. Cannot be null or empty.</param>
		/// <returns>Parsed boolean.</returns>
		public bool GetBoolFromRequest(string paramName) {

			string str = GetStringFormRequest(paramName);

			bool val;
			if (!bool.TryParse(str, out val)) {
				throw new RequestException("Parameter '" + paramName + "' cannot be converted to boolean");
			}

			return val;

		}

		/// <summary>
		/// Returns a GUID from the web request, throwing an exception if the parameter is not
		/// specified or its format is invalid.
		/// </summary>
		/// <param name="name">Name of the parameter containing the GUID</param>
		/// <returns>Parsed GUID object. Cannot be Empty.</returns>
		public Guid GetGuidFromRequest(string name) {

			return GetGuidFromRequest(name, true);

		}

		/// <summary>
		/// Gets a GUID from the web request.
		/// </summary>
		/// <param name="name">Parameter name</param>
		/// <param name="throwIfNotFound">Whether to throw an exception if the parameter is not found.</param>
		/// <returns>Parsed GUID object. Can be Empty, if throwIfNotFound is false.</returns>
		public Guid GetGuidFromRequest(string name, bool throwIfNotFound) {

			string str = request.QueryString.Get(name);

			if (!String.IsNullOrEmpty(str)) {
				var guid = new Guid(str);
				return guid;
			}

			if (throwIfNotFound)
				throw new RequestException("Missing request parameter: " + name);

			return Guid.Empty;

		}

		/// <summary>
		/// Gets an integer from the web request.
		/// </summary>
		/// <param name="paramName">Parameter name. Cannot be null or empty.</param>
		/// <returns>Parsed integer.</returns>
		public int GetIntFromRequest(string paramName) {

			string str = GetStringFormRequest(paramName);

			int val;
			if (!int.TryParse(str, out val)) {
				throw new RequestException("Parameter '" + paramName + "' cannot be converted to integer");
			}

			return val;

		}

		/// <summary>
		/// Gets a string parameter from request, throwing an exception if the
		/// parameter is not specified.
		/// </summary>
		/// <param name="paramName">Name of the parameter. Cannot be null or empty.</param>
		/// <returns>The string parameter. Cannot be null.</returns>
		public string GetStringFormRequest(string paramName) {

			string str = request.Params.Get(paramName);

			if (String.IsNullOrEmpty(str)) {
				throw new RequestException("Missing request parameter: " + paramName);
			}

			return str;

		}

		/// <summary>
		/// Gets a string parameter from request, returning a default value if the
		/// parameter is not specified.
		/// </summary>
		/// <param name="paramName">Name of the parameter. Cannot be null or empty.</param>
		/// <param name="defaultValue">Default value.</param>
		/// <returns>The string parameter. Cannot be null.</returns>
		public string GetStringFormRequest(string paramName, string defaultValue) {

			string str = request.QueryString.Get(paramName);
			return str ?? defaultValue;

		}

		/// <summary>
		/// Attempts to get an int parameter from the request.
		/// </summary>
		/// <param name="paramName">Parameter name.</param>
		/// <param name="value">Parameter value converted to int.</param>
		/// <returns>True if the parameter was specified and was successfully converted to integer. Otherwise false.</returns>
		public bool TryGetInt(string paramName, out int value) {

			string str = request.QueryString.Get(paramName);

			return int.TryParse(str, out value);

		}

	}
}