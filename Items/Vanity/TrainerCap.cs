using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerramonMod.Items.Vanity
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	[AutoloadEquip(EquipType.Head)]
	public class TrainerCap : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Pokemon Trainer Cap");
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;

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
