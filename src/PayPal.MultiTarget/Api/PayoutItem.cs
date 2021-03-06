//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PayPal.Util;

namespace PayPal.Api
{
    /// <summary>
    /// A sender-created definition of a payout to a single recipient.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class PayoutItem : PayPalResource
    {
        /// <summary>
        /// The type of ID that identifies the payment receiver. Value is:<ul><code>EMAIL</code>. Unencrypted email. Value is a string of up to 127 single-byte characters.</li><li><code>PHONE</code>. Unencrypted phone number.<blockquote><strong>Note:</strong> The PayPal sandbox does not support the <code>PHONE</code> recipient type.</blockquote></li><li><code>PAYPAL_ID</code>. Encrypted PayPal account number.</li></ul>If the <code>sender_batch_header</code> includes the <code>recipient_type</code> attribute, any payout item without its own <code>recipient_type</code> attribute uses the <code>recipient_type</code> value from <code>sender_batch_header</code>. If the <code>sender_batch_header</code> omits the <code>recipient_type</code> attribute, each payout item must include its own <code>recipient_type</code> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "recipient_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PayoutRecipientType recipient_type { get; set; }

        /// <summary>
        /// The amount of money to pay the receiver.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }

        /// <summary>
        /// Optional. A sender-specified note for notifications. Value is any string value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note")]
        public string note { get; set; }

        /// <summary>
        /// The receiver of the payment. Corresponds to the `recipient_type` value in the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public string receiver { get; set; }

        /// <summary>
        /// A sender-specified ID number. Tracks the batch payout in an accounting system.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_item_id")]
        public string sender_item_id { get; set; }

        /// <summary>
        /// Obtain the status of a payout item by passing the item ID to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="payoutItemId">Payouts generated payout_item_id to obtain status.</param>
        /// <returns>PayoutItemDetails</returns>
        public static PayoutItemDetails Get(APIContext apiContext, string payoutItemId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(payoutItemId, "payoutItemId");

            // Configure and send the request
            var pattern = "v1/payments/payouts-item/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { payoutItemId });
            return PayPalResource.ConfigureAndExecute<PayoutItemDetails>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Cancels the unclaimed payment using the items id passed in the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="payoutItemId">Payouts generated payout_item_id to obtain status.</param>
        /// <returns>PayoutItemDetails</returns>
        public static PayoutItemDetails Cancel(APIContext apiContext, string payoutItemId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(payoutItemId, "payoutItemId");

            // Configure and send the request
            var pattern = "v1/payments/payouts-item/{0}/cancel";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { payoutItemId });
            return PayPalResource.ConfigureAndExecute<PayoutItemDetails>(apiContext, HttpMethod.POST, resourcePath);
        }
    }
}
