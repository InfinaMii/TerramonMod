using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerramonMod.Items.Vanity
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	[AutoloadEquip(EquipType.Body)]
	public class TrainerTorso : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Pokemon Trainer Jacket");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 3000;
			Item.rare = ItemRarityID.White;
			Item.vanity = true;
		}
	}
}
