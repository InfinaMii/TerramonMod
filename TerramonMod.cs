using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using TerramonMod.Items;
using System.Diagnostics;
using System.IO;
using ReLogic.Content;
using Terraria.UI;
using TerramonMod.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TerramonMod.Items.Pokeballs;

namespace TerramonMod
{
	public class TerramonMod : Mod
	{
		public static bool fastAnimations = false;
		public static bool fastEvolution = true;
		public static bool randomStarters = false;

		public enum PkmnType
		{
			none,
			normal,
			fire,
			water,
			grass,
			electric,
			ice,
			fighting,
			poison,
			ground,
			flying,
			psychic,
			bug,
			rock,
			ghost,
			dragon,
            dark,
            steel,
            fairy
		}

		public override void Load()
		{
			// All of this loading needs to be client-side.

			if (Main.netMode != NetmodeID.Server)
			{
				Ref<Effect> fxPkmnSpawnRef = new Ref<Effect>(ModContent.Request<Effect>("TerramonMod/Effects/PkmnSpawn", AssetRequestMode.ImmediateLoad).Value);
				GameShaders.Misc["fxPkmnSpawn"] = new MiscShaderData(fxPkmnSpawnRef, "TerramonShaderPass");
			}
		}

        public override void PostSetupContent()
        {
			//Compatibility with Dialogue Panel Rework mod
			if (ModLoader.TryGetMod("DialogueTweak", out Mod dialogueTweak))
			{
				dialogueTweak.Call(
					"ReplaceExtraButtonIcon",
					ModContent.NPCType<NPCs.PokemartClerk>(),
					"TerramonMod/UI/EvolveIcon"
					);
			}

			//Compatibility with Achievement Mod
			/*if (ModLoader.TryGetMod("TMLAchievements", out Mod achievements))
			{
				achievements.Call("AddAchievement", this,
					"TerramonAchievement",
					Terraria.Achievements.AchievementCategory.Collector,
					"TerramonMod/Achievements/JourneyStart",
					null,
					false, false, 1f, new string[] { "Collect_" + ModContent.ItemType<PokeBallItem>() });
			}*/
		}

        public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			TmonMessageType msgType = (TmonMessageType)reader.ReadByte();
			switch (msgType)
			{
				// This message syncs summoned pokemon
				case TmonMessageType.SyncPlayerState:
					byte playernumber = reader.ReadByte();
					TerramonPlayer tmonPlayer = Main.player[playernumber].GetModPlayer<TerramonPlayer>();
					int usePokePet = reader.ReadInt32();
					bool usePokeIsShiny = reader.ReadBoolean();

					tmonPlayer.usePokePet = usePokePet;
					tmonPlayer.usePokeIsShiny = usePokeIsShiny;

					// SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
					break;
				case TmonMessageType.ChangePlayerState:
					playernumber = reader.ReadByte();
					tmonPlayer = Main.player[playernumber].GetModPlayer<TerramonPlayer>();
					usePokePet = reader.ReadInt32();
					usePokeIsShiny = reader.ReadBoolean();

					tmonPlayer.usePokePet = usePokePet;
					tmonPlayer.usePokeIsShiny = usePokeIsShiny;
					// Unlike SyncPlayer, here we have to relay/forward these changes to all other connected clients
					if (Main.netMode == NetmodeID.Server)
					{
						var packet = GetPacket();
						packet.Write((byte)TmonMessageType.ChangePlayerState);
						packet.Write(playernumber);
						packet.Write(usePokePet);
						packet.Write(usePokeIsShiny);
						packet.Send(-1, playernumber);
					}
					break;
			}
		}

		internal enum TmonMessageType : byte
		{
			SyncPlayerState,
			ChangePlayerState,
		}
	}
}