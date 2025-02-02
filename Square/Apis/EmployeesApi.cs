namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Request.Configuration;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// EmployeesApi.
    /// </summary>
    internal class EmployeesApi : BaseApi, IEmployeesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal EmployeesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// ListEmployees.
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by..</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page..</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results..</param>
        /// <returns>Returns the Models.ListEmployeesResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListEmployeesResponse ListEmployees(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListEmployeesResponse> t = this.ListEmployeesAsync(locationId, status, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// ListEmployees.
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by..</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page..</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEmployeesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListEmployeesResponse> ListEmployeesAsync(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/employees");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "status", status },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListEmployeesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// RetrieveEmployee.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveEmployeeResponse RetrieveEmployee(
                string id)
        {
            Task<Models.RetrieveEmployeeResponse> t = this.RetrieveEmployeeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// RetrieveEmployee.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveEmployeeResponse> RetrieveEmployeeAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/employees/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveEmployeeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}