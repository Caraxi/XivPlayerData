using Newtonsoft.Json;

namespace XivPlayerData {
	public class ITEMFDR_Inventory {

		public StackableItem[] Items { get; private set; }

		[JsonConverter(typeof(UnknownDataJsonConverter))]
		public byte[] RetainerHeader { get; set; } = new byte[0];

		public ITEMFDR_Inventory(ushort itemCount) {
			Items = new StackableItem[itemCount];
			for (int i=0;i<itemCount;i++){
				Items[i] = new StackableItem();
			}
		}
	}

}
