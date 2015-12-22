// Template: Client Proxy T4 Template (RAMLClient.t4) version 4.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RAML.Api.Core;
using Raml.Common;

namespace RAMLDemo.Api.Tests.Api
{
    public partial class StatusParcelId
    {
        private readonly ParcelDeliveryApiClient proxy;

        internal StatusParcelId(ParcelDeliveryApiClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Retrieves the current status for the specified parcel ID. - Parcel Status Information
		/// </summary>
		/// <param name="parcelId"></param>
        public virtual async Task<Models.StatusParcelIdGetResponse> Get(string parcelId)
        {

            var url = "status/{parcelId}";
            url = url.Replace("{parcelId}", parcelId.ToString());
            var req = new HttpRequestMessage(HttpMethod.Get, url);
	        var response = await proxy.Client.SendAsync(req);
			
			if (proxy.SchemaValidation.Enabled)
		    {
				if(proxy.SchemaValidation.RaiseExceptions) 
				{
					await SchemaValidator.ValidateWithExceptionAsync(Models.StatusParcelIdGetResponse.GetSchema(response.StatusCode), response.Content);
				}
					
			}

            return new Models.StatusParcelIdGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => SchemaValidator.IsValid(Models.StatusParcelIdGetResponse.GetSchema(response.StatusCode), response.Content), true)
                                            };

        }

        /// <summary>
		/// Retrieves the current status for the specified parcel ID. - Parcel Status Information
		/// </summary>
		/// <param name="request">Models.StatusParcelIdGetRequest</param>
		/// <param name="responseFormatters">response formmaters</param>
        public virtual async Task<Models.StatusParcelIdGetResponse> Get(Models.StatusParcelIdGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "status/{parcelId}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.ParcelId == null)
				throw new InvalidOperationException("Uri Parameter ParcelId cannot be null");

            url = url.Replace("{parcelId}", request.UriParameters.ParcelId.ToString());
            var req = new HttpRequestMessage(HttpMethod.Get, url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
			if (proxy.SchemaValidation.Enabled && proxy.SchemaValidation.RaiseExceptions)
            {
				if(proxy.SchemaValidation.RaiseExceptions)
				{
					await SchemaValidator.ValidateWithExceptionAsync(Models.StatusParcelIdGetResponse.GetSchema(response.StatusCode), response.Content);
				}
				
            }
            return new Models.StatusParcelIdGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => SchemaValidator.IsValid(Models.StatusParcelIdGetResponse.GetSchema(response.StatusCode), response.Content), true)
                                            };
        }


        /// <summary>
		/// Creates or updates the status for the specified parcel ID. - Parcel Status Information
		/// </summary>
		/// <param name="statusparcelidputrequestcontent"></param>
		/// <param name="parcelId"></param>
        public virtual async Task<Models.StatusParcelIdPutResponse> Put(Models.StatusParcelIdPutRequestContent statusparcelidputrequestcontent, string parcelId)
        {

            var url = "status/{parcelId}";
            url = url.Replace("{parcelId}", parcelId.ToString());
            var req = new HttpRequestMessage(HttpMethod.Put, url);
            req.Content = new ObjectContent(typeof(Models.StatusParcelIdPutRequestContent), statusparcelidputrequestcontent, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);
			
			if (proxy.SchemaValidation.Enabled)
		    {
				if(proxy.SchemaValidation.RaiseExceptions) 
				{
					await SchemaValidator.ValidateWithExceptionAsync(Models.StatusParcelIdPutResponse.GetSchema(response.StatusCode), response.Content);
				}
					
			}

            return new Models.StatusParcelIdPutResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => SchemaValidator.IsValid(Models.StatusParcelIdPutResponse.GetSchema(response.StatusCode), response.Content), true)
                                            };

        }

        /// <summary>
		/// Creates or updates the status for the specified parcel ID. - Parcel Status Information
		/// </summary>
		/// <param name="request">Models.StatusParcelIdPutRequest</param>
		/// <param name="responseFormatters">response formmaters</param>
        public virtual async Task<Models.StatusParcelIdPutResponse> Put(Models.StatusParcelIdPutRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "status/{parcelId}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.ParcelId == null)
				throw new InvalidOperationException("Uri Parameter ParcelId cannot be null");

            url = url.Replace("{parcelId}", request.UriParameters.ParcelId.ToString());
            var req = new HttpRequestMessage(HttpMethod.Put, url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            if(request.Formatter == null)
                request.Formatter = new JsonMediaTypeFormatter();
	        var response = await proxy.Client.SendAsync(req);
			if (proxy.SchemaValidation.Enabled && proxy.SchemaValidation.RaiseExceptions)
            {
				if(proxy.SchemaValidation.RaiseExceptions)
				{
					await SchemaValidator.ValidateWithExceptionAsync(Models.StatusParcelIdPutResponse.GetSchema(response.StatusCode), response.Content);
				}
				
            }
            return new Models.StatusParcelIdPutResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => SchemaValidator.IsValid(Models.StatusParcelIdPutResponse.GetSchema(response.StatusCode), response.Content), true)
                                            };
        }

    }

    /// <summary>
    /// Main class for grouping root resources. Nested resources are defined as properties. The constructor can optionally receive an URL and HttpClient instance to override the default ones.
    /// </summary>
    public partial class ParcelDeliveryApiClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "https://raml-demo-api.azurewebsites.net/{version}/";

        internal HttpClient Client { get { return client; } }




        public ParcelDeliveryApiClient(string endpointUrl)
        {
            SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};

			if(string.IsNullOrWhiteSpace(endpointUrl))
                throw new ArgumentException("You must specify the endpoint URL", "endpointUrl");

			if (endpointUrl.Contains("{"))
			{
				var regex = new Regex(@"\{([^\}]+)\}");
				var matches = regex.Matches(endpointUrl);
				var parameters = new List<string>();
				foreach (Match match in matches)
				{
					parameters.Add(match.Groups[1].Value);
				}
				throw new InvalidOperationException("Please replace parameter/s " + string.Join(", ", parameters) + " in the URL before passing it to the constructor ");
			}

            client = new HttpClient {BaseAddress = new Uri(endpointUrl)};
        }

        public ParcelDeliveryApiClient(HttpClient httpClient)
        {
            if(httpClient.BaseAddress == null)
                throw new InvalidOperationException("You must set the BaseAddress property of the HttpClient instance");

            client = httpClient;

			SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};
        }

        

        public virtual StatusParcelId StatusParcelId
        {
            get { return new StatusParcelId(this); }
        }
                


		public void AddDefaultRequestHeader(string name, string value)
		{
			client.DefaultRequestHeaders.Add(name, value);
		}

		public void AddDefaultRequestHeader(string name, IEnumerable<string> values)
		{
			client.DefaultRequestHeaders.Add(name, values);
		}


    }

} // end namespace









namespace RAMLDemo.Api.Tests.Api.Models
{
    public partial class  ErrorMessage 
    {

        /// <summary>
        /// The error message of the error.
        /// </summary>
		[JsonProperty("message")]
        public string Message { get; set; }


    } // end class

    public partial class  StatusParcelIdPutRequestContent 
    {

        /// <summary>
        /// The new status update message.
        /// </summary>
		[JsonProperty("status")]
        public string Status { get; set; }


    } // end class

    public partial class  StatusParcelIdGetOKResponseContent 
    {

        /// <summary>
        /// The current status of the delivery.
        /// </summary>
		[JsonProperty("status")]
        public string Status { get; set; }


        /// <summary>
        /// The date time the last status update.
        /// </summary>
		[JsonProperty("updated")]
        public string Updated { get; set; }


    } // end class

    public partial class  StatusParcelIdGetNotFoundResponseContent 
    {

        /// <summary>
        /// The error message of the error.
        /// </summary>
		[JsonProperty("message")]
        public string Message { get; set; }


    } // end class

    public partial class  StatusParcelIdGetNotAcceptableResponseContent 
    {

        /// <summary>
        /// The error message of the error.
        /// </summary>
		[JsonProperty("message")]
        public string Message { get; set; }


    } // end class

    public partial class  StatusParcelIdPutNotFoundResponseContent 
    {

        /// <summary>
        /// The error message of the error.
        /// </summary>
		[JsonProperty("message")]
        public string Message { get; set; }


    } // end class

    public partial class  StatusParcelIdPutNotAcceptableResponseContent 
    {

        /// <summary>
        /// The error message of the error.
        /// </summary>
		[JsonProperty("message")]
        public string Message { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types StatusParcelIdGetOKResponseContent, StatusParcelIdGetNotFoundResponseContent, StatusParcelIdGetNotAcceptableResponseContent
    /// </summary>
    public partial class  MultipleStatusParcelIdGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
			{ (HttpStatusCode)200, "{  \"$schema\": \"http://json-schema.org/draft-04/schema#\",  \"title\": \"Delivery Status\",  \"type\": \"object\",  \"properties\": {    \"status\": {      \"description\": \"The current status of the delivery.\",      \"type\": \"string\"    },    \"updated\": {      \"description\": \"The date time the last status update.\",      \"type\": \"string\"    }  }}"},
			{ (HttpStatusCode)404, "{  \"$schema\": \"http://json-schema.org/draft-04/schema#\",  \"title\": \"Error Message\",  \"type\": \"object\",  \"properties\": {                     \"message\": {      \"description\": \"The error message of the error.\",      \"type\": \"string\"    }  }}"},
			{ (HttpStatusCode)406, "{  \"$schema\": \"http://json-schema.org/draft-04/schema#\",  \"title\": \"Error Message\",  \"type\": \"object\",  \"properties\": {                     \"message\": {      \"description\": \"The error message of the error.\",      \"type\": \"string\"    }  }}"},
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleStatusParcelIdGet()
        {
            names.Add((HttpStatusCode)200, "StatusParcelIdGetOKResponseContent");
            types.Add((HttpStatusCode)200, typeof(StatusParcelIdGetOKResponseContent));
            names.Add((HttpStatusCode)404, "StatusParcelIdGetNotFoundResponseContent");
            types.Add((HttpStatusCode)404, typeof(StatusParcelIdGetNotFoundResponseContent));
            names.Add((HttpStatusCode)406, "StatusParcelIdGetNotAcceptableResponseContent");
            types.Add((HttpStatusCode)406, typeof(StatusParcelIdGetNotAcceptableResponseContent));
        }

        /// <summary>
        /// Current status. 
        /// </summary>
        public StatusParcelIdGetOKResponseContent StatusParcelIdGetOKResponseContent { get; set; }


        /// <summary>
        /// Could not find the specified parcel ID. 
        /// </summary>
        public StatusParcelIdGetNotFoundResponseContent StatusParcelIdGetNotFoundResponseContent { get; set; }


        /// <summary>
        /// Parcel ID was in an incorrect format. 
        /// </summary>
        public StatusParcelIdGetNotAcceptableResponseContent StatusParcelIdGetNotAcceptableResponseContent { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types StatusParcelIdPutNotFoundResponseContent, StatusParcelIdPutNotAcceptableResponseContent
    /// </summary>
    public partial class  MultipleStatusParcelIdPut : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
			{ (HttpStatusCode)404, "{  \"$schema\": \"http://json-schema.org/draft-04/schema#\",  \"title\": \"Error Message\",  \"type\": \"object\",  \"properties\": {                     \"message\": {      \"description\": \"The error message of the error.\",      \"type\": \"string\"    }  }}"},
			{ (HttpStatusCode)406, "{  \"$schema\": \"http://json-schema.org/draft-04/schema#\",  \"title\": \"Error Message\",  \"type\": \"object\",  \"properties\": {                     \"message\": {      \"description\": \"The error message of the error.\",      \"type\": \"string\"    }  }}"},
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleStatusParcelIdPut()
        {
            names.Add((HttpStatusCode)404, "StatusParcelIdPutNotFoundResponseContent");
            types.Add((HttpStatusCode)404, typeof(StatusParcelIdPutNotFoundResponseContent));
            names.Add((HttpStatusCode)406, "StatusParcelIdPutNotAcceptableResponseContent");
            types.Add((HttpStatusCode)406, typeof(StatusParcelIdPutNotAcceptableResponseContent));
        }

        /// <summary>
        /// Could not find the specified parcel ID. 
        /// </summary>
        public StatusParcelIdPutNotFoundResponseContent StatusParcelIdPutNotFoundResponseContent { get; set; }


        /// <summary>
        /// Parcel ID was in an incorrect format. 
        /// </summary>
        public StatusParcelIdPutNotAcceptableResponseContent StatusParcelIdPutNotAcceptableResponseContent { get; set; }


    } // end class

    /// <summary>
    /// Uri Parameters for resource /status/{parcelId}
    /// </summary>
    public partial class  StatusParcelIdUriParameters 
    {

		[JsonProperty("parcelId")]
        public string ParcelId { get; set; }


    } // end class

    /// <summary>
    /// Request object for method Get of class StatusParcelId
    /// </summary>
    public partial class StatusParcelIdGetRequest : ApiRequest
    {
        public StatusParcelIdGetRequest(StatusParcelIdUriParameters UriParameters)
        {
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public StatusParcelIdUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Put of class StatusParcelId
    /// </summary>
    public partial class StatusParcelIdPutRequest : ApiRequest
    {
        public StatusParcelIdPutRequest(StatusParcelIdUriParameters UriParameters, StatusParcelIdPutRequestContent Content = null, MediaTypeFormatter Formatter = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public StatusParcelIdPutRequestContent Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public StatusParcelIdUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Get of class StatusParcelId
    /// </summary>

    public partial class StatusParcelIdGetResponse : ApiResponse
    {

	    private MultipleStatusParcelIdGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleStatusParcelIdGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleStatusParcelIdGet();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleStatusParcelIdGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Put of class StatusParcelId
    /// </summary>

    public partial class StatusParcelIdPutResponse : ApiResponse
    {

	    private MultipleStatusParcelIdPut typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleStatusParcelIdPut Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleStatusParcelIdPut();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleStatusParcelIdPut.GetSchema(statusCode);
        }      

    } // end class


} // end Models namespace
