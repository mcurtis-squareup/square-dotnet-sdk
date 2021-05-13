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
    /// CreateOrderRequest.
    /// </summary>
    public class CreateOrderRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateOrderRequest(
            Models.Order order = null,
            string idempotencyKey = null)
        {
            this.Order = order;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// order among orders you have created.
        /// If you are unsure whether a particular order was created successfully,
        /// you can try it again with the same idempotency key without
        /// worrying about creating duplicate orders.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateOrderRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateOrderRequest other &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -934891871;

            if (this.Order != null)
            {
               hashCode += this.Order.GetHashCode();
            }

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Order order;
            private string idempotencyKey;

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateOrderRequest. </returns>
            public CreateOrderRequest Build()
            {
                return new CreateOrderRequest(
                    this.order,
                    this.idempotencyKey);
            }
        }
    }
}