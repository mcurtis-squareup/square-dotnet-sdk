namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// ListCatalogRequest.
    /// </summary>
    public class ListCatalogRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCatalogRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="types">types.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public ListCatalogRequest(
            string cursor = null,
            string types = null,
            long? catalogVersion = null)
        {
            this.Cursor = cursor;
            this.Types = types;
            this.CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// The page size is currently set to be 100.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// An optional case-insensitive, comma-separated list of object types to retrieve.
        /// The valid values are defined in the [CatalogObjectType]($m/CatalogObjectType) enum, for example,
        /// `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,
        /// `MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.
        /// If this is unspecified, the operation returns objects of all the top level types at the version
        /// of the Square API used to make the request. Object types that are nested onto other object types
        /// are not included in the defaults.
        /// At the current API version the default object types are:
        /// ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST, DINING_OPTION, TAX_EXEMPTION,
        /// SERVICE_CHARGE, PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT,
        /// SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS.
        /// </summary>
        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; }

        /// <summary>
        /// The specific version of the catalog objects to be included in the response.
        /// This allows you to retrieve historical
        /// versions of objects. The specified version value is matched against
        /// the [CatalogObject]($m/CatalogObject)s' `version` attribute.  If not included, results will
        /// be from the current version of the catalog.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListCatalogRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is ListCatalogRequest other &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Types == null && other.Types == null) || (this.Types?.Equals(other.Types) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1348170902;
            hashCode = HashCode.Combine(this.Cursor, this.Types, this.CatalogVersion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Types = {(this.Types == null ? "null" : this.Types == string.Empty ? "" : this.Types)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Types(this.Types)
                .CatalogVersion(this.CatalogVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private string types;
            private long? catalogVersion;

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// Types.
             /// </summary>
             /// <param name="types"> types. </param>
             /// <returns> Builder. </returns>
            public Builder Types(string types)
            {
                this.types = types;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCatalogRequest. </returns>
            public ListCatalogRequest Build()
            {
                return new ListCatalogRequest(
                    this.cursor,
                    this.types,
                    this.catalogVersion);
            }
        }
    }
}