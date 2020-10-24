using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImpedanceCalculator
{
	public class SegmentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(ISegment));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return serializer.Deserialize(reader, typeof(ISegment));
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value, typeof(ISegment));
		}

		public static ISegment DeserialiseProduct(string json)
		{
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new SegmentConverter());

			ISegment product = JsonConvert.DeserializeObject<ISegment>(json, settings);

			return product;
		}
	}
}
