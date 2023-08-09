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
using TerramonMod.Items.Vanity;
using TerramonMod.Projectiles;
using static Terraria.GameContent.Profiles;

namespace TerramonMod.NPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    
    public class PokemartClerk : ModNPC
    {
        private static int ShimmerHeadIndex;
        private static StackedNPCProfile NPCProfile;
        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Poke Mart Clerk");

            Main.npcFrameCount[Type] = 26; // The amount of frames the NPC has
            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 2; // For when a party is active, the party hat spawns at a Y offset.
            NPCID.Sets.ShimmerTownTransform[Type] = true;

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<CorruptionBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<CrimsonBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Princess, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Pirate, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate)
            ; // < Mind the semicolon!

            //breeder - bestiarygirl, nurse    stylist, partygirl

            // This creates a "profile" for our NPC, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new StackedNPCProfile(
                new DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture)),
                new DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Hatless")
            );
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Merchant);
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 20;
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
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ => true;

        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Martin",
                "Tom",
                "Dave",
                "Morshu",
                "Terry",
                "Steven",
                "Xavier",
                "Asher",
                "Pikachu",
                "Lance"
            };
        }

        public override string GetChat()
        {
            var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
            if (player.pokeInUse != null && player.pokeInUse.data.IsEvolveReady())
                return $"Oh? It look's like {player.pokeInUse.data.GetName()} is ready to evolve.";

            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add("There's a lot of Pokemon out there, but you'll need Poke Balls to catch them! Luckily for you, I have some in stock.");
            chat.Add("In Johto they have a species of Pokémon called Furrets. They sure do love to walk!");
            //chat.Add("As your journey progresses, I'll offer new things. Check back here every so often.");
            chat.Add("Different Pokémon like living in different places. If you travel around, you may find new Pokemon!");
            chat.Add("There are many different regions in the world. One day I hope to visit all of them!");
            //chat.Add("I conveniently sell Pokéballs for you to buy, but if you're short of cash you can always make your own using apricorns and iron!");
            chat.Add("A remake of Mobile Creatures has been announced! Though I'm not sure how I feel about the art style...");
            chat.Add($"Ever since Pokémon started appearing in {Main.worldName}, I've dedicated my life to helping people learn more about them.");
            chat.Add("The Pokémon around here seem very peaceful. It's unusual to see creatures geting along so well.");

            if (NPC.GivenName == "Pikachu")
                chat.Add("Now, I know what you're thinking. \"That's such a creative name!\"");

            //only add chat about Pokemon if it exists
            if (player.pokeInUse != null)
            {
                chat.Add($"Is that your {player.pokeInUse.data.GetInfo().Name}? Hi, {player.pokeInUse.data.GetName()}!");

                if (player.pokeInUse.data.Nickname == null)
                    chat.Add("Did you know you can give your Pokemon a nickname? Type \"/nickname \" in the chat alongside the name of your choice.");
                else
                    chat.Add($"{player.pokeInUse.data.Nickname}? That's a lovely name! I can tell you care about your Pokemon very much.");

                var pokemonType = player.pokeInUse.data.GetInfo().type1;
                if (pokemonType == TerramonMod.PkmnType.grass)
                    chat.Add($"Is that a grass type Pokemon? Those are my favourite!");
                else if (pokemonType == TerramonMod.PkmnType.ice)
                    chat.Add($"An Ice type Pokemon! I've always loved seeing those.");

                if (player.usePokeIsShiny)
                    chat.Add("Is that a shiny Pokemon? That's incredible! I wish I had one myself.");
                else if (player.usePokeIsShimmer)
                    chat.Add("Interesting... Your Pokemon has the same colors as a shiny Pokemon, but none of the... well- shine.");
            }

            if (NPC.IsShimmerVariant)
                chat.Add("Like my outfit? I look just like a real Pokemon Trainer!");
            else
                chat.Add("Have you heard of Shimmer? Apparently it can give people their own shiny form!");

            var merchant = NPC.FindFirstNPC(NPCID.Merchant);
            if (merchant >= 0)
                chat.Add(Language.GetTextValue($"{Main.npc[merchant].GivenName} may be a bit greedy, but he has taught me everything I know about commerce."));

            var mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic >= 0)
                chat.Add(Language.GetTextValue($"{Main.npc[mechanic].GivenName} knows a lot about Poke Balls. Maybe one day I could start selling more of them!"));

            var pirate = NPC.FindFirstNPC(NPCID.Pirate);
            if (pirate >= 0)
                chat.Add(Language.GetTextValue($"Have you tried speaking to {Main.npc[pirate].GivenName}? I can never understand what he is saying."));

            var armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (armsDealer >= 0)
                chat.Add(Language.GetTextValue($"Can you tell {Main.npc[armsDealer].GivenName} to stop shooting at the Pokemon??"));

            return chat; // chat is implicitly cast to a string.
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28");

            var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
            if (player.pokeInUse != null && player.pokeInUse.data.IsEvolveReady())
                button2 = "Evolve";
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                Main.LocalPlayer.GetModPlayer<TerramonPlayer>().premierBonusCount = 0;
                shopName = "Shop";
            }
            else
            {
                var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
                var pokeName = player.pokeInUse.data.GetName();
                player.pokeInUse.data.Evolve(null, false);
                player.pokeInUse.UpdateName();
                Main.npcChatText = $"Congratulations! Your {pokeName} evolved into {player.pokeInUse.data.GetInfo().Name}!";
            }
        }

        public static Condition TrainerSetCondition = new Condition("ClerkTrainerSale", () => Condition.IsNpcShimmered.IsMet() || Main.halloween);

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, "Shop")
                .Add<PokeBallItem>()
                .Add<GreatBallItem>()
                .Add<UltraBallItem>()
                .Add<TrainerCap>(TrainerSetCondition)
                .Add<TrainerTorso>(TrainerSetCondition)
                .Add<TrainerLegs>(TrainerSetCondition);

            npcShop.Register(); // Name of this shop tab
        }


        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue) => true;

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<PokeBomb>();
            attackDelay = 1;
        }
    }

    /*public class PokemartClerkProfile : ITownNPCProfile
    {
        private string texture;
        private string partyTexture;
        private int headIndex;

        public PokemartClerkProfile(string texture, int headIndex, string partyTexture = null)
        {
            this.texture = texture;
            if (partyTexture != null)
                this.partyTexture = partyTexture;
            else
                this.partyTexture = texture;
            this.headIndex = headIndex;
        }

        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.ForcePartyHatOn)
                return ModContent.Request<Texture2D>(partyTexture);
            else
                return ModContent.Request<Texture2D>(texture);
        }

        public int GetHeadTextureIndex(NPC npc) => headIndex;
    }*/
}
