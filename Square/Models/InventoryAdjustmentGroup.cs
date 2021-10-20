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
    /// InventoryAdjustmentGroup.
    /// </summary>
    public class InventoryAdjustmentGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryAdjustmentGroup"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="rootAdjustmentId">root_adjustment_id.</param>
        /// <param name="fromState">from_state.</param>
        /// <param name="toState">to_state.</param>
        public InventoryAdjustmentGroup(
            string id = null,
            string rootAdjustmentId = null,
            string fromState = null,
            string toState = null)
        {
            this.Id = id;
            this.RootAdjustmentId = rootAdjustmentId;
            this.FromState = fromState;
            this.ToState = toState;
        }

        /// <summary>
        /// A unique ID generated by Square for the
        /// `InventoryAdjustmentGroup`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The inventory adjustment of the composed variation.
        /// </summary>
        [JsonProperty("root_adjustment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RootAdjustmentId { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("from_state", NullValueHandling = NullValueHandling.Ignore)]
        public string FromState { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("to_state", NullValueHandling = NullValueHandling.Ignore)]
        public string ToState { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryAdjustmentGroup : ({string.Join(", ", toStringOutput)})";
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

            return obj is InventoryAdjustmentGroup other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.RootAdjustmentId == null && other.RootAdjustmentId == null) || (this.RootAdjustmentId?.Equals(other.RootAdjustmentId) == true)) &&
                ((this.FromState == null && other.FromState == null) || (this.FromState?.Equals(other.FromState) == true)) &&
                ((this.ToState == null && other.ToState == null) || (this.ToState?.Equals(other.ToState) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1783874998;
            hashCode = HashCode.Combine(this.Id, this.RootAdjustmentId, this.FromState, this.ToState);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.RootAdjustmentId = {(this.RootAdjustmentId == null ? "null" : this.RootAdjustmentId == string.Empty ? "" : this.RootAdjustmentId)}");
            toStringOutput.Add($"this.FromState = {(this.FromState == null ? "null" : this.FromState.ToString())}");
            toStringOutput.Add($"this.ToState = {(this.ToState == null ? "null" : this.ToState.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .RootAdjustmentId(this.RootAdjustmentId)
                .FromState(this.FromState)
                .ToState(this.ToState);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string rootAdjustmentId;
            private string fromState;
            private string toState;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// RootAdjustmentId.
             /// </summary>
             /// <param name="rootAdjustmentId"> rootAdjustmentId. </param>
             /// <returns> Builder. </returns>
            public Builder RootAdjustmentId(string rootAdjustmentId)
            {
                this.rootAdjustmentId = rootAdjustmentId;
                return this;
            }

             /// <summary>
             /// FromState.
             /// </summary>
             /// <param name="fromState"> fromState. </param>
             /// <returns> Builder. </returns>
            public Builder FromState(string fromState)
            {
                this.fromState = fromState;
                return this;
            }

             /// <summary>
             /// ToState.
             /// </summary>
             /// <param name="toState"> toState. </param>
             /// <returns> Builder. </returns>
            public Builder ToState(string toState)
            {
                this.toState = toState;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryAdjustmentGroup. </returns>
            public InventoryAdjustmentGroup Build()
            {
                return new InventoryAdjustmentGroup(
                    this.id,
                    this.rootAdjustmentId,
                    this.fromState,
                    this.toState);
            }
        }
    }
}