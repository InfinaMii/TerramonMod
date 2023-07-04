using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using TerramonMod.Items.Pokeballs;

namespace TerramonMod.NPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class PokemartClerk : ModNPC
    {
		public int NumberOfTimesTalkedTo;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poke Mart Clerk");

			Main.npcFrameCount[Type] = 26; // The amount of frames the NPC has
			NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			// Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
			// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
			NPC.Happiness
				//.SetBiomeAffection<Biome>
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Love) // Example Person likes the desert.
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
				.SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate) // Hates living near the demolitionist.
			; // < Mind the semicolon!
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Merchant);
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement($"The Poke Mart Clerk is a dedicated salesman, stocking all kinds of items for your Pokemon training needs."),

			});
		}
		public override bool CanTownNPCSpawn(int numTownNPCs, int money) => true;

		public override ITownNPCProfile TownNPCProfile()
		{
			return new PokemartClerkProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Ash",
				"Somebody",
				"Blocky",
				"Colorless"
			};
		}

		public override string GetChat()
		{
			var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
			if (player.pokeInUse != null && player.pokeInUse.data.IsEvolveReady() == 1)
				return $"Oh? It look's like {player.pokeInUse.data.GetName()} is ready to evolve.";

			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("There's a lot of Pokemon out there, but you'll need Poke Balls to catch them! Luckily for you, I have some in stock.");
			chat.Add("In Johto they have a species of Pokémon called Furrets. They sure do love to walk!");
			//chat.Add("As your journey progresses, I'll offer new things. Check back here every so often.");
			chat.Add("Different Pokémon like living in different places. If you travel around, you may find new Pokemon!");
			chat.Add("There are many different regions in the world. One day I hope to visit all of them!");
			chat.Add("I conveniently sell Pokéballs for you to buy, but if you're short of cash you can always make your own using apricorns and iron!");
			chat.Add("A remake of Mobile Creatures has been announced! Though I'm not sure how I feel about the art style...");
			chat.Add($"Ever since Pokémon started appearing in {Main.worldName}, I've dedicated my life to helping people care for them properly.");
			chat.Add("The Pokémon around here seem very peaceful. It's unusual to see creatures geting along so well.");

			return chat; // chat is implicitly cast to a string.
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{ // What the chat buttons are when you open up the chat UI
			button = Language.GetTextValue("LegacyInterface.28");

			var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
			if (player.pokeInUse != null && player.pokeInUse.data.IsEvolveReady() == 1)
				button2 = "Evolve";
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			if (firstButton)
				shop = true;
			else
            {
				var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
				player.pokeInUse.data.Evolve();
				player.pokeInUse.UpdateName();
			}
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<PokeBallItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<GreatBallItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<UltraBallItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<MasterBallItem>());
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) => true;
	}

	public class PokemartClerkProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			return ModContent.Request<Texture2D>("TerramonMod/NPCs/PokemartClerk");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TerramonMod/NPCs/PokemartClerk_Head");
	}
}
