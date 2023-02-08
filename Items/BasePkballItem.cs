﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerramonMod.Items.Pokeballs;
using TerramonMod.Pokemon;
using TerramonMod.Pokemon.Gen1;

namespace TerramonMod.Items
{
	public class BasePkballItem : ModItem
	{
		bool preUpdateName = false;
		public virtual int pokeballThrow => ModContent.ProjectileType<BasePkballProjectile>();
		public virtual int igPrice => -1; //ingame price (from pokemon games) so price scaling matches

		public PkmnData data = null;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault($"BasePkball");
			Tooltip.SetDefault("Throw it to catch a Pokemon!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; //Amount of Pokeballs needed to duplicate them in Journey Mode
		}


		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Shuriken);
			Item.shoot = pokeballThrow;
			Item.shootSpeed = 6.5f;
			Item.UseSound = null;
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.damage = 0;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
			Item.value = igPrice * 2;
		}

		public override bool CanShoot(Player player) => (data == null);

		public override bool CanUseItem(Player player) => (player.altFunctionUse != 2); //Don't execute this code if the alternate function is being executed

		public void SetUnsellable()
        {
			Item.value = -1;
		}

        public override void UpdateInventory(Player player)
        {
			if (!preUpdateName)
			{
				UpdateName();
				preUpdateName = true;
			}
		}
		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			//spriteBatch.Draw(ModContent.GetContent<>(Texture), position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);

			if (data != null)
			{
				string suffix = "";
				if (data.isShiny)
					suffix = "_Shiny";

				Texture2D pokemonSprite = ModContent.Request<Texture2D>($"TerramonMod/Minisprites/mini{data.GetInfo().Name}{suffix}").Value;
				spriteBatch.Draw(pokemonSprite, new Vector2(position.X - (12 * scale), position.Y - (16 * scale)), null, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
			}
		}
		public void UpdateName()
        {
			if (data != null)
				Item.SetNameOverride($"{Lang.GetItemName(Type)} ({data.GetName()})");
			else
				Item.SetNameOverride(Lang.GetItemName(Type).ToString());
		}

		public override bool? UseItem(Player player) //Manage what happens when the player uses the item
        {
			var tmonPlayer = player.GetModPlayer<TerramonPlayer>();
			if (data == null)
			{
				Item.consumable = true;
				//Projectile.NewProjectile(Item.GetSource_ItemUse(Item), player.position, player.DirectionTo(Main.MouseWorld) * 6.5f, pokeballThrow, 0, 0, Main.myPlayer);
				SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_throw"), player.position);
			}
			else if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				Item.consumable = false;
				SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkmn_spawn"), player.position);


				if (tmonPlayer.pokeInUse != Item.ModItem as BasePkballItem)
					tmonPlayer.pokeInUse = Item.ModItem as BasePkballItem;
				else
					tmonPlayer.pokeInUse = null;

				player.AddBuff(ModContent.BuffType<PkmnBuff>(), 3600); //Add pokemon buff (will auto-remove if pokemon isn't released)
			}

			return true;
		}

		public override bool CanStack(Item item2)
        {
			var other = (BasePkballItem)item2.ModItem;
			if (data == null && other.data == null) //Only stack if both items are empty
				return true;
			return false;
        }
		public override bool CanStackInWorld(Item item2) => CanStack(item2);

		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (data != null)
            {
				int position = tooltips.FindIndex(t => t.Name.Contains("Tooltip") || t.Name == "Consumable");

                while (position > -1)
                {
                    tooltips.RemoveAt(position); //remove default tooltips and item names
                    position = tooltips.FindIndex(t => t.Name.Contains("Tooltip") || t.Name == "Consumable");
                }

				tooltips.Add(new TooltipLine(Mod, "Tooltip0", $"A device for catching wild Pokémon."));
				tooltips.Add(new TooltipLine(Mod, "Tooltip1", $"It contains a Level {data.level} {data.GetInfo().Name}."));

				
			}
        }

        //Serialize and deserialise pokeball contents on save/load (tagcompound can't save classes but it can save string)
        public override void SaveData(TagCompound tag)
        {
			tag.Set(nameof(data), JsonConvert.SerializeObject(data));
        }

		public override void LoadData(TagCompound tag)
		{
			data = JsonConvert.DeserializeObject<PkmnData>(tag.Get<string>(nameof(data)));

			if (data != null && data.pkmn == null)
				data = null;
		}

		public override void NetSend(BinaryWriter writer)
        {
            var localData = data;
            if (data == null)
                localData = new PkmnData ();

			var nickname = localData.Nickname;
			if (nickname == null)
				nickname = "unnamedPkmn";

			var pkmn = localData.pkmn;
			if (pkmn == null)
				pkmn = "emptyPkmn";

			writer.Write(data != null);
            writer.Write(localData.level);
            writer.Write(pkmn);
            writer.Write(nickname);

        }

        public override void NetReceive(BinaryReader reader)
        {
            var hasData = reader.ReadBoolean();
            var level = reader.ReadInt32();
            var pkmn = reader.ReadString();
            var nickname = reader.ReadString();

			if (hasData)
			{
				if (nickname == "unnamedPkmn")
					nickname = null;

				if (pkmn == "emptyPkmn")
					pkmn = null;

				data = new PkmnData();
				data.level = level;
				data.Nickname = nickname;
				data.pkmn = pkmn;
			}
			else
				data = null;
		}

		public override bool AltFunctionUse(Player player)
        {
			if (data != null)
				Main.NewText(data.ToString(), Color.Pink);			
			else
			{
				string msg = "";
				//data = new PkmnData { pkmn = ModContent.NPCType<CharmeleonNPC>(), level = 16 };
				foreach (var p in Main.player)
				{
					if (p.name != "")
						msg += $"{p.name}: {p.GetModPlayer<TerramonPlayer>().usePokePet}-{p.GetModPlayer<TerramonPlayer>().usePokeIsShiny}, ";
				}
				Main.NewText(msg, Color.MediumPurple);
			}

            return true;
        }

        /*public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}*/
    }
}