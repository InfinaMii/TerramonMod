using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerramonMod.Items;
using TerramonMod.Items.Pokeballs;
using TerramonMod.Pokemon;
using TerramonMod;

namespace TerramonMod
{
    class TerramonPlayer : ModPlayer
    {
        public int introPhase = 0;

        public BasePkballItem pokeInUse = null;

		public int usePokePet = -1;
		public bool usePokeIsShiny = false;

		public int premierBonusCount = 0;

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (mediumCoreDeath)
                return Enumerable.Empty<Item>();

            introPhase = -1;

            return new[] {
                new Item(ModContent.ItemType<PokeBallItem>(), 5),
            };
        }

		public override void SaveData(TagCompound tag)
        {
			tag.Set(nameof(introPhase), introPhase);
		}

		public override void LoadData(TagCompound tag)
		{
			introPhase = tag.Get<int>(nameof(introPhase));
		}

		public override void PreUpdate()
        {
			if (Main.LocalPlayer == Player) //Only change these values if they belong to this client (other clients' pokeInUse for this player always null)
			{
				UpdatePkmn();
			}	
		}

		public void UpdatePkmn()
        {
			if (!Player.HasBuff(ModContent.BuffType<PkmnBuff>())) //remove pokemon if no buff exists (no pokemon is visble)
				pokeInUse = null;

			if (pokeInUse != null)
			{
				usePokePet = pokeInUse.data.GetInfo().petType;
				usePokeIsShiny = pokeInUse.data.isShiny;
			}
			else
				usePokePet = -1;
		}

        public override void PostBuyItem(NPC vendor, Item[] shopInventory, Item item)
        {
			if (item.type == ModContent.ItemType<PokeBallItem>())
				premierBonusCount++;
			if (premierBonusCount == 10)
			{
				Player.QuickSpawnItem(Player.GetSource_GiftOrReward(), ModContent.ItemType<PremierBallItem>());
				premierBonusCount = 0;
			}
        }

        // In MP, other clients need accurate information about your player or else bugs happen.
        // clientClone, SyncPlayer, and SendClientChanges, ensure that information is correct.
        // We only need to do this for data that is changed by code not executed by all clients, 
        // or data that needs to be shared while joining a world.
        // For example, examplePet doesn't need to be synced because all clients know that the player is wearing the ExamplePet item in an equipment slot. 
        // The examplePet bool is set for that player on every clients computer independently (via the Buff.Update), keeping that data in sync.
        // ExampleLifeFruits, however might be out of sync. For example, when joining a server, we need to share the exampleLifeFruits variable with all other clients.
        // In addition, in ExampleUI we have a button that toggles "Non-Stop Party". We need to sync this whenever it changes.
        public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
		{
			TerramonPlayer clone = clientClone as TerramonPlayer;
			// Here we would make a backup clone of values that are only correct on the local players Player instance.
			// Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
			clone.usePokePet = usePokePet;
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)TerramonMod.TmonMessageType.SyncPlayerState);
			packet.Write((byte)Player.whoAmI);
			packet.Write(usePokePet); // While we sync nonStopParty in SendClientChanges, we still need to send it here as well so newly joining players will receive the correct value.
			packet.Write(usePokeIsShiny);
			packet.Send(toWho, fromWho);
		}

		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			// Here we would sync something like an RPG stat whenever the player changes it.
			TerramonPlayer clone = clientPlayer as TerramonPlayer;
			if (clone.usePokePet != usePokePet || clone.usePokeIsShiny != usePokeIsShiny)
			{
				// Send a Mod Packet with the changes.
				var packet = Mod.GetPacket();
				packet.Write((byte)TerramonMod.TmonMessageType.ChangePlayerState);
				packet.Write((byte)Player.whoAmI);
				packet.Write(usePokePet);
				packet.Write(usePokeIsShiny);
				packet.Send();
			}
		}
	}
}
