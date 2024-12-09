// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;
namespace Kiota.Api.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class WeatherForecast : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The date property</summary>
        public Date? Date { get; set; }
        /// <summary>The summary property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Summary { get; set; }
#nullable restore
#else
        public string Summary { get; set; }
#endif
        /// <summary>The temperatureC property</summary>
        public int? TemperatureC { get; set; }
        /// <summary>The temperatureF property</summary>
        public int? TemperatureF { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Kiota.Api.Client.Models.WeatherForecast"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Kiota.Api.Client.Models.WeatherForecast CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Kiota.Api.Client.Models.WeatherForecast();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "date", n => { Date = n.GetDateValue(); } },
                { "summary", n => { Summary = n.GetStringValue(); } },
                { "temperatureC", n => { TemperatureC = n.GetIntValue(); } },
                { "temperatureF", n => { TemperatureF = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateValue("date", Date);
            writer.WriteStringValue("summary", Summary);
            writer.WriteIntValue("temperatureC", TemperatureC);
            writer.WriteIntValue("temperatureF", TemperatureF);
        }
    }
}
#pragma warning restore CS0618
