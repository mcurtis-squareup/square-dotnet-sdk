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
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;

namespace Square.Apis
{
    internal class ApplePayApi : BaseApi, IApplePayApi
    {
        internal ApplePayApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation
        /// is performed on this domain by Apple to ensure that it is properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// To learn more about Web Apple Pay, see
        /// [Add the Apple Pay on the Web Button](https://developer.squareup.com/docs/payment-form/add-digital-wallets/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        public Models.RegisterDomainResponse RegisterDomain(Models.RegisterDomainRequest body)
        {
            Task<Models.RegisterDomainResponse> t = RegisterDomainAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation
        /// is performed on this domain by Apple to ensure that it is properly set up as
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// To learn more about Web Apple Pay, see
        /// [Add the Apple Pay on the Web Button](https://developer.squareup.com/docs/payment-form/add-digital-wallets/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RegisterDomainResponse response from the API call</return>
        public async Task<Models.RegisterDomainResponse> RegisterDomainAsync(Models.RegisterDomainRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/apple-pay/domains");

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryBuilder.ToString(), _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["global"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RegisterDomainResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}