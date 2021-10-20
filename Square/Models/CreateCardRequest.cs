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
    /// CreateCardRequest.
    /// </summary>
    public class CreateCardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCardRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="sourceId">source_id.</param>
        /// <param name="card">card.</param>
        /// <param name="verificationToken">verification_token.</param>
        public CreateCardRequest(
            string idempotencyKey,
            string sourceId,
            Models.Card card,
            string verificationToken = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.SourceId = sourceId;
            this.VerificationToken = verificationToken;
            this.Card = card;
        }

        /// <summary>
        /// A unique string that identifies this CreateCard request. Keys can be
        /// any valid string and must be unique for every request.
        /// Max: 45 characters
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the source which represents the card information to be stored. This can be a card nonce or a payment id.
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; }

        /// <summary>
        /// An identifying token generated by [Payments.verifyBuyer()](https://developer.squareup.com/reference/sdks/web/payments/objects/Payments#Payments.verifyBuyer).
        /// Verification tokens encapsulate customer device information and 3-D Secure
        /// challenge results to indicate that Square has verified the buyer identity.
        /// See the [SCA Overview](https://developer.squareup.com/docs/sca-overview).
        /// </summary>
        [JsonProperty("verification_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationToken { get; }

        /// <summary>
        /// Represents the payment details of a card to be used for payments. These
        /// details are determined by the payment token generated by Web Payments SDK.
        /// </summary>
        [JsonProperty("card")]
        public Models.Card Card { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCardRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCardRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.SourceId == null && other.SourceId == null) || (this.SourceId?.Equals(other.SourceId) == true)) &&
                ((this.VerificationToken == null && other.VerificationToken == null) || (this.VerificationToken?.Equals(other.VerificationToken) == true)) &&
                ((this.Card == null && other.Card == null) || (this.Card?.Equals(other.Card) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 732228113;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.SourceId, this.VerificationToken, this.Card);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.SourceId = {(this.SourceId == null ? "null" : this.SourceId == string.Empty ? "" : this.SourceId)}");
            toStringOutput.Add($"this.VerificationToken = {(this.VerificationToken == null ? "null" : this.VerificationToken == string.Empty ? "" : this.VerificationToken)}");
            toStringOutput.Add($"this.Card = {(this.Card == null ? "null" : this.Card.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.SourceId,
                this.Card)
                .VerificationToken(this.VerificationToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string sourceId;
            private Models.Card card;
            private string verificationToken;

            public Builder(
                string idempotencyKey,
                string sourceId,
                Models.Card card)
            {
                this.idempotencyKey = idempotencyKey;
                this.sourceId = sourceId;
                this.card = card;
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
             /// SourceId.
             /// </summary>
             /// <param name="sourceId"> sourceId. </param>
             /// <returns> Builder. </returns>
            public Builder SourceId(string sourceId)
            {
                this.sourceId = sourceId;
                return this;
            }

             /// <summary>
             /// Card.
             /// </summary>
             /// <param name="card"> card. </param>
             /// <returns> Builder. </returns>
            public Builder Card(Models.Card card)
            {
                this.card = card;
                return this;
            }

             /// <summary>
             /// VerificationToken.
             /// </summary>
             /// <param name="verificationToken"> verificationToken. </param>
             /// <returns> Builder. </returns>
            public Builder VerificationToken(string verificationToken)
            {
                this.verificationToken = verificationToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCardRequest. </returns>
            public CreateCardRequest Build()
            {
                return new CreateCardRequest(
                    this.idempotencyKey,
                    this.sourceId,
                    this.card,
                    this.verificationToken);
            }
        }
    }
}