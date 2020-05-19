using Newtonsoft.Json;

namespace XivPlayerData {
	public class Retainer : ITEMFDR_Inventory {

		public Item[] Equipment { get; } = new Item[14];

		#if DEBUG
		[JsonConverter(typeof(UnknownDataJsonConverter))]
		#else
		[JsonIgnore]
		#endif
		public byte[] RetainerPadding { get; internal set; }

		public Retainer() : base(175) {
			for (int i=0;i<Equipment.Length;i++){
				Equipment[i] = new Item();
			}
		}
	}

}
