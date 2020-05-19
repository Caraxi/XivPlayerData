using System;
using System.Text;
using Newtonsoft.Json;

namespace XivPlayerData {
	public class UnknownDataJsonConverter : JsonConverter {

		public override bool CanConvert(Type objectType) {
			return objectType.IsArray && objectType == typeof(byte);
		}
		public override bool CanRead => false;

		public override bool CanWrite => true;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			StringBuilder sb = new StringBuilder();
			byte[] bytes = (byte[])value;
			foreach(byte b in bytes){
				sb.Append($"{(b ^ 0x73):X2} ");
			}
			writer.WriteValue(sb.ToString().Trim());
		}
	}

}
