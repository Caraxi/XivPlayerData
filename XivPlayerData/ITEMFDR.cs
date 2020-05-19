using Newtonsoft.Json;

namespace XivPlayerData {

	public class ITEMFDR {

		#if DEBUG
		[JsonConverter(typeof(UnknownDataJsonConverter))]
		#else
		[JsonIgnore]
		#endif
		public byte[] FileHeader { get; set; } = new byte[0];
		#if DEBUG
		[JsonConverter(typeof(UnknownDataJsonConverter))]
		#else
		[JsonIgnore]
		#endif
		public byte[] Unknown1 { get; set; } = new byte[0];

		public Retainer[] Retainers { get; set; }
		
		public Item[] GlamourDresser { get; private set; }
		public StackableItem[] SaddleBag { get; private set; }

		#if DEBUG
		[JsonConverter(typeof(UnknownDataJsonConverter))]
		#else
		[JsonIgnore]
		#endif
		public byte[] Unknown2 { get; internal set; }

		public ITEMFDR() {
			Retainers = new Retainer[10];
			for (int i=0;i<Retainers.Length;i++){
				Retainers[i] = new Retainer();
			}

			GlamourDresser = new Item[400];
			for (int i=0;i<GlamourDresser.Length;i++){
				GlamourDresser[i] = new Item();
			}

			SaddleBag = new StackableItem[140];
			for (int i=0;i<SaddleBag.Length;i++){
				SaddleBag[i] = new StackableItem();
			}

		}

	}

}
