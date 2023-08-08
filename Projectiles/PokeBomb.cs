using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerramonMod.Items.Pokeballs;
using TerramonMod.Pokemon;
using Terraria.GameContent.Events;

namespace TerramonMod.Projectiles
{
    class PokeBomb : ModProjectile
    {
        int bounces = 2;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1; //frames in spritesheet
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
        }

        public override void SetDefaults()
        {
            Projectile.width = 24; //Set to size of spritesheet
            Projectile.height = 24;
            Projectile.damage = 20;
            Projectile.aiStyle = ProjAIStyleID.Explosive;
            Projectile.penetrate = 1;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //return base.OnTileCollide(oldVelocity);
            if (bounces > 0)
            {
                bounces -= 1;
                Projectile.velocity.Y = oldVelocity.Y *= -0.7f;
                Projectile.velocity.X = oldVelocity.X *= 0.5f;

                SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_bounce"), Projectile.position);

                if (Projectile.velocity.Length() < 1.5f)
                    bounces = 0;
            }
            else
                DeleteSelf();

            return false;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity += Main.player[Projectile.owner].velocity * 0.75f;
            if (Sandstorm.Happening && Main.player[Projectile.owner].ZoneDesert)
                Projectile.velocity.X -= 1.75f;
        }

        public override void AI()
        {
            if (Projectile.shimmerWet)
            {
                 if (bounces > 0 && Projectile.velocity.Y < 0)
                {
                    Projectile.shimmerWet = false;
                    Projectile.velocity.Y *= -0.8f;
                    SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_bounce"), Projectile.position);
                    bounces -= 1;
                }
            }
            base.AI();
        }

        public override bool? CanDamage() => true;

        void DeleteSelf()
        {
            var proj = Projectile.NewProjectile(Projectile.GetSource_None(), Projectile.position, Projectile.velocity, ProjectileID.Grenade, 20, 8);
            var ectile = Main.projectile[proj];
            ectile.Kill();
            Projectile.active = false;
            /*var point1 = new Point((int)(Projectile.position.X / 1) - 2, (int)(Projectile.position.Y / 8) - 1);
            var point2 = new Point((int)(Projectile.position.X / 1) + 2, (int)(Projectile.position.Y / 8) + 1);
            Projectile.CreateImpactExplosion(1, Projectile.position, ref point1, ref point2, 2, out bool b);*/
        }

    }

    /*public class PokeBombItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Grenade);
            Item.shoot = ModContent.ProjectileType<PokeBomb>();
            Item.shootSpeed = 6.5f;
            Item.damage = 20;
            Item.UseSound = new SoundStyle("TerramonMod/Sounds/pkball_throw");
        }
    }*/
}
