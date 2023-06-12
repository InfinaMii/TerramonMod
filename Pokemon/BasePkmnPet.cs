using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TerramonMod.Pokemon;
using Terraria.DataStructures;
using TerramonMod.Pokemon.Dusts;

namespace TerramonMod.Pokemon
{
	public class BasePkmnPet : ModProjectile
	{
		int currentFrame = 0;
		int frameTimer = 0; //added these because the default ones were being weird T-T

		public virtual bool doesFly => false;
		private enum Frame
		{
			Walk1,
			Walk2
		}

		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bunny);
			if (doesFly)
				AIType = ProjectileID.ZephyrFish; // Copy the AI of the Zephyr Fish.
			else
				AIType = ProjectileID.Bunny; // Copy the AI of the Bunny Pet.
			Projectile.width = 32;
			Projectile.height = 32;
		}

        public override void OnSpawn(IEntitySource source)
        {
			//Face player's direction and move ahead of player
			int direction = Main.player[Projectile.owner].direction;
			Projectile.direction = direction;
			if (direction == -1)
				Projectile.position.X -= 36;
			else
				Projectile.position.X += 48;

			var dust = ModContent.DustType<summoncloud>();
			var mainPosition = new Vector2(Projectile.position.X - (Projectile.width / 2), Projectile.position.Y - (Projectile.height / 2));
			Dust.NewDust(new Vector2(mainPosition.X, mainPosition.Y + 4), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X, mainPosition.Y - 4), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X + 4, mainPosition.Y), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X - 4, mainPosition.Y), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X + 2, mainPosition.Y + 2), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X + 2, mainPosition.Y - 2), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X - 2, mainPosition.Y + 2), Projectile.width, Projectile.height, dust);
			Dust.NewDust(new Vector2(mainPosition.X - 2, mainPosition.Y - 2), Projectile.width, Projectile.height, dust);

			//Main.NewText(direction, Color.White);
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];

			player.bunny = false; // Relic from aiType

			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			if (player.GetModPlayer<TerramonPlayer>().usePokePet != Type)
				Projectile.active = false; //delete myself (if usePokePet changed it will be respawned by buff)


			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<PkmnBuff>())) {
				Projectile.timeLeft = 2;
			}

			Animate();
        }

        public override bool PreDraw(ref Color lightColor)
		{
			Player player = Main.player[Projectile.owner];

			// get the sprite path
			string spritePath = Texture;

			if (player.GetModPlayer<TerramonPlayer>().usePokeIsShiny)
			{
				spritePath += "_Shiny";
			}

			// load the sprite using the sprite path
			Texture2D sprite = ModContent.Request<Texture2D>(spritePath).Value;

			// draw the sprite
			//base.PreDraw(ref lightColor);
			var frame = new Rectangle(0, currentFrame * 32, 32, 32);
			//Main.EntitySpriteDraw(sprite, Projectile.Center, new Rectangle(0, Projectile.frame * 32, 32, 32), lightColor, Projectile.rotation, Projectile.Size / 2, Projectile.scale * 2, Projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
			Main.EntitySpriteDraw(sprite, new Vector2(Projectile.Center.X - (frame.Width * 0.21f), Projectile.Center.Y - (frame.Height * 0.39f)) - Main.screenPosition, frame, lightColor, Projectile.rotation, Projectile.Size / 2, Projectile.scale * 2, Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
			return false;
		}

		void Animate()
        {
			//Main.NewText(Projectile.velocity, Color.Green);
			if (GetMoveSpeed() > 0.75f)
			{
				if (frameTimer >= 20 / (GetMoveSpeed() / 2))
				{
					if (currentFrame == (int)Frame.Walk1)
						currentFrame = (int)Frame.Walk2;
					else
						currentFrame = (int)Frame.Walk1;
					frameTimer = 0;
				}
				frameTimer++;
			}
			//else
			//frameTimer = 0;

			var tmonPlayer = Main.player[Projectile.owner].GetModPlayer<TerramonPlayer>();
			if (tmonPlayer.pokeInUse != null && tmonPlayer.pokeInUse.data.IsEvolveReady() == 1)
            {
				if ((int)Main.rand.Next(0, 60) == 0)
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.TreasureSparkle);
			}

			Projectile.frame = currentFrame;
		}

		float GetMoveSpeed() => Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y);

	}
}
