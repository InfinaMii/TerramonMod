using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TerramonMod.Items;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon
{
    class BasePkmn : ModNPC
    {
		public virtual PkmnInfo info => null;
		public virtual int wildLevel => 0;
		public virtual float commodity => 1f;
		public virtual bool doesFly => false;

		public bool isShiny = false;
		public bool catchable = true;
		public int catchAttempts = 0;
		public int level = -1;

		private enum ActionState
		{
			Idle,
			Walk
		}

		private enum Frame
		{
			Walk1,
			Walk2
		}

		// These are reference properties. One, for example, lets us write AI_State as if it's NPC.ai[0], essentially giving the index zero our own name.
		// Here they help to keep our AI code clear of clutter. Without them, every instance of "AI_State" in the AI code below would be "npc.ai[0]", which is quite hard to read.
		// This is all to just make beautiful, manageable, and clean code.
		public ref float AI_State => ref NPC.ai[0];
		public ref float AI_Timer => ref NPC.ai[1];
		public ref float AI_Random => ref NPC.ai[2];

		public override void SetStaticDefaults()
		{
			if (info != null)
				DisplayName.SetDefault(info.Name);
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			//NPC.CloneDefaults(NPCID.Bunny);

			if (doesFly)
			{
				//NPC.CloneDefaults(NPCID.Butterfly);
				NPC.aiStyle = NPCAIStyleID.Firefly;
				AIType = NPCID.Firefly;
				
			}
			else
			{
				NPC.CloneDefaults(NPCID.Bunny);
				
				NPC.aiStyle = NPCAIStyleID.Passive; //change to -1 if writing custom movement AI
				//NPC.noGravity = false;
			}

			NPC.width = 32;
			NPC.height = 32;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 99;
			NPC.HitSound = null;
			NPC.DeathSound = null;
			NPC.netAlways = true;
			//NPC.noGravity = true;
			//NPC.wet = true;
			//NPC.scale = 2;
			//NPC.dontTakeDamage = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			float spawnChance = 0f;

			if (wildLevel != 0)
				return 0;

			if (this.Type == ModContent.NPCType<BasePkmn>())
                return 0;

            switch (info.type1)
            {
                case PkmnType.fire:
                    if (spawnInfo.Player.ZoneUnderworldHeight)
                        spawnChance = commodity;
                    break;
                case PkmnType.normal:
                    if (spawnInfo.Player.ZoneForest)
                        spawnChance = commodity;
                    break;
					// TODO: add in spawning for more types
            }

            return spawnChance * 0.05f;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.spriteDirection = NPC.direction;
			//Main.NewText(Projectile.velocity, Color.Green);
			if (GetMoveSpeed() > 0.75f)
			{
				if (NPC.frameCounter >= 20 / (GetMoveSpeed() / 2))
				{
					if (NPC.frame.Y == (int)Frame.Walk1 * frameHeight)
						NPC.frame.Y = (int)Frame.Walk2 * frameHeight;
					else
						NPC.frame.Y = (int)Frame.Walk1 * frameHeight;
					NPC.frameCounter = 0;
				}
				NPC.frameCounter++;
			}
			//else
			//frameTimer = 0;
		}

		float GetMoveSpeed() => Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y);

		public override void AI()
        {
			if (info == null)
				NPC.active = false;
			AI_Timer += 1;

			if (level == -1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
				var shinyChance = Main.rand.Next(0, 4096);
				if (shinyChance == 0)
					isShiny = true;
				level = Main.rand.Next(1, 5);
			}

			//info.Nickname = null;

			base.AI();
			//Main.NewText($"Timer: {AI_Timer}, Frames: {NPC.frameCounter}, Random: {AI_Random}, State: {AI_State}");
			/*if (Collision.SolidCollision(new Vector2(NPC.position.X + NPC.direction, NPC.position.Y - 1), NPC.width, NPC.height))
			{
				NPC.velocity.X *= -1;
				NPC.velocity.Y = 2;
			}*/
				//NPC.direction *= -1;

			/*if (AI_Timer >= 120)
			{
				AI_Timer = 0;
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					AI_Random = (int)Main.rand.Next(0, 8);
					NPC.netUpdate = true;
				}

				if (AI_Random <= 1)
				{
					if (AI_State == (int)ActionState.Idle)
					{
						if (AI_Random == 1)
							NPC.direction *= -1;
						AI_State = (int)ActionState.Walk;
					}
					else
						AI_State = (int)ActionState.Idle;
				}
			}

			switch (AI_State)
            {
                case (int)ActionState.Walk:
					NPC.velocity.X = 8 * NPC.direction;
					break;
				case (int)ActionState.Idle:
					NPC.velocity.X = 0;
					break;
            }*/

        }

        /*public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix); // SpriteSortMode needs to be set to Immediate for shaders to work.

				if (!catchable)
                    GameShaders.Misc["fxPkmnSpawn"].Apply();
            }

			return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix); // SpriteSortMode needs to be set to Immediate for shaders to work.
		}*/


		public void Destroy()
        {
			NPC.netUpdate = true;
			catchable = false;
			for (int i = 0; i < 32; i++)
			{
				var offsetx = Main.rand.NextFloat(NPC.width * -0.5f, NPC.width * 0.5f);
				var offsety = Main.rand.NextFloat(NPC.height * -0.5f, NPC.height * 0.5f);

				Dust.NewDust(new Vector2(NPC.position.X + offsetx, NPC.position.Y + offsety), NPC.width, NPC.height, DustID.Cloud);
			}
			NPC.active = false;
		}

        /*public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			damage = 0;
			knockback = 0;
			crit = false;
			hitDirection = 0;
        }*/

		public override void UpdateLifeRegen(ref int damage)
		{
			NPC.life = NPC.lifeMax;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			// get the sprite path
			string spritePath = Texture;
			if (isShiny)
			{
				spritePath += "_Shiny";
			}

			// load the sprite using the sprite path
			Texture2D sprite = ModContent.Request<Texture2D>(spritePath).Value;

			// draw the sprite
			spriteBatch.Draw(sprite, new Vector2(NPC.Center.X - (NPC.frame.Width * 0.19f), NPC.Center.Y - (NPC.frame.Height * 0.39f)) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.Size / 2, NPC.scale * 2, NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
			return false;
		}

		/*public override void HitEffect(int hitDirection, double damage)
        {
            //base.HitEffect(hitDirection, damage);
        }*/

        public override bool? CanBeHitByProjectile(Projectile projectile)
		{
			if (!catchable)
				return false;
			if (projectile.ModProjectile is BasePkballProjectile)
				return true;
			return false;
		}

		public override bool? CanBeHitByItem(Player player, Item item) => false;

        public override void SendExtraAI(BinaryWriter writer)
        {
			writer.Write(isShiny);
			writer.Write(level);
		}

        public override void ReceiveExtraAI(BinaryReader reader)
        {
			var isShinyVar = reader.ReadBoolean();
			var levelVar = reader.ReadInt32();

			if (Main.netMode != NetmodeID.Server) // server sets these data so shouldn't recieve it
            {
				isShiny = isShinyVar;
				level = levelVar;
            }
		}
    }
}
