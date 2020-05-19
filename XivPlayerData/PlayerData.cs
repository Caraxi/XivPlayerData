using System;
using System.IO;

namespace XivPlayerData {
	public class PlayerData {

		private static readonly uint XOR_73_32 = 0x73737373;
		private static readonly ushort XOR_73_16 = 0x7373;

		public static ITEMFDR GetItemFDR(string CHR_DIRECTORY) {

			var documentsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var chrDir = Path.Combine(documentsDir, "My Games", "FINAL FANTASY XIV - A Realm Reborn", CHR_DIRECTORY);
			var itemfdrPath = Path.Combine(chrDir, "ITEMFDR.dat");
			ITEMFDR itemFdr = new ITEMFDR();
			using (FileStream fs = new FileStream(itemfdrPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, FileOptions.None)){
				using (BinaryReader br = new BinaryReader(fs)){
					itemFdr.FileHeader = br.ReadBytes(0x10);
					foreach(Retainer retainer in itemFdr.Retainers) {
						
						retainer.RetainerHeader = br.ReadBytes(0x23);

						foreach(Item item in retainer.Equipment) {
							uint id = br.ReadUInt32() ^ XOR_73_32;
							if (id > 1000000) {
								item.HQ = false;
								id -= 1000000;
							}
							item.ItemId = id;
						}

						foreach(StackableItem item in retainer.Items) {
							uint id = br.ReadUInt32() ^ XOR_73_32;
							if (id > 1000000) {
								item.HQ = true;
								id -= 1000000;
							}
							item.ItemId = id;
						}

						foreach(StackableItem item in retainer.Items) {
							item.Quantity = (ushort)(br.ReadUInt16() ^ XOR_73_16);
						}

						retainer.RetainerPadding = br.ReadBytes(0x0E);

					}

					itemFdr.Unknown1 = br.ReadBytes(0x20);

					foreach(StackableItem item in itemFdr.SaddleBag) {
						uint id = br.ReadUInt32() ^ XOR_73_32;
						if (id > 1000000){
							item.HQ = true;
							id -= 1000000;
						}
						item.ItemId = id;
					}
					foreach(StackableItem item in itemFdr.SaddleBag) {
						item.Quantity = (ushort)(br.ReadUInt16() ^ XOR_73_16);
					}

					itemFdr.Unknown2 = br.ReadBytes(0x04);

					foreach(Item item in itemFdr.GlamourDresser) {
						uint id = br.ReadUInt32() ^ XOR_73_32;
						if (id > 1000000){
							item.HQ = true;
							id -= 1000000;
						}
						item.ItemId = id;
					}
				}
			}

			return itemFdr;
		}

	}
}
