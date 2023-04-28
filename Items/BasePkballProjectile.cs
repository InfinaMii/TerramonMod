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

namespace TerramonMod.Items
{
    class BasePkballProjectile : ModProjectile
    {
        public virtual int pokeballCapture => ModContent.ItemType<BasePkballItem>();
        public virtual float catchModifier { get; set; }
        BasePkmn capture = null; //Type of pokemon to be caught
        float rotation = 0;
        int bounces = 5;
        float rotationVelocity = 0;
        float catchRandom = -1;
        int catchTries = 3;
        bool caught = false;
        float speedMultiply = 1;

        bool hasContainedLocal = false;
        bool hasCalculatedCapture = false;

        private enum Frame //Here we label all of the frames in the spritesheet for better readability
        {
            Throw,
            Catch,
            Capture,
            CaptureComplete
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4; //frames in spritesheet
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
        }

        public override void SetDefaults()
        {
            Projectile.width = 24; //Set to size of spritesheet
            Projectile.height = 24;
            //Projectile.damage = 1;
            Projectile.aiStyle = -1; //aiStyle -1 so no vanilla styles interfere with custom ai
            Projectile.penetrate = -1; //How many npcs to collide before being deleted (-1 makes this infinite)
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
            else if (Projectile.ai[1] == 0)
            {
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                for (int i = 0; i < 6; i++)
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Iron);
                return true;
            }
            else if (Projectile.ai[1] == 1 && bounces == 0) //only randomise catch number and play sound once
            {
                //caught = CatchPokemonChances(capture);
                if (Main.player[Projectile.owner].whoAmI == Main.myPlayer) //Generate new catch chance, (will switch pokeball to catching anim when value is recieved by clients)
                    catchRandom = Main.rand.NextFloat(0, 1);
                SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_bounce"), Projectile.position);
                bounces = -1;
            }

            return false;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            var captureId = -1;
            if (capture != null)
                captureId = capture.NPC.whoAmI; //BinaryWriter can't send BasePkmn, so we send the NPC's number instead

            writer.Write(catchRandom);
            writer.Write(captureId);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            var catchRandomVar = reader.ReadSingle();
            var captureId = reader.ReadInt32();

            if (catchRandom == -1)
                catchRandom = catchRandomVar;
            if (capture == null && captureId != -1) //only change capture if none exists
                capture = Main.npc[captureId].ModNPC as BasePkmn;
        }

        public override void AI()
        {
            //Main.NewText(catchRandom, Color.Pink);
            if (TerramonMod.fastAnimations)
                speedMultiply = 0.65f;

            Projectile.damage = 1;
            Projectile.ai[0]++;
            ///Projectile.spriteDirection = Projectile.direction;
            ///
            if (hasContainedLocal == false && capture != null)
                HitPkmn(capture.NPC);
            if (catchRandom > -1 && !hasCalculatedCapture)
            {
                hasCalculatedCapture = true;
                caught = CatchPokemonChances(capture, catchRandom);
                Projectile.ai[0] = 0;
                Projectile.ai[1] = 2;
            }

            if (Projectile.ai[1] == 0)
            {
                Projectile.frame = (int)Frame.Throw; //At state 1 should use throw sprite
                Projectile.rotation += Projectile.velocity.X * 0.05f; //Spin in air (feels better than static) based on current velocity so it slows down once it hits the ground
                if (Projectile.ai[0] >= 10f)
                {
                    Projectile.ai[0] = 10f; //Wait 10 frames before apply gravity, then keep timer at 10 so it gets constantly applied
                    Projectile.velocity.Y = Projectile.velocity.Y + 0.25f; //(positive Y value makes projectile go down)
                }
            }
            else if (Projectile.ai[1] == 1)
            {
                if (capture != null && capture.catchable)
                {
                    capture.Destroy(); //Destroy Pokemon NPC
                }

                if (Projectile.ai[0] < 35 * speedMultiply) //Stay still (no velocity) if 50 frames havent passed yet (60fps)
                {
                    Projectile.frame = (int)Frame.Catch;
                    Projectile.rotation = rotation;
                    Projectile.velocity.X = 0;
                    Projectile.velocity.Y = 0;
                }
                else
                {
                    Projectile.frame = (int)Frame.Capture;
                    Projectile.rotation = 0;
                    Projectile.velocity.Y += 0.25f; //Add to Y velocity so projectile moves downwards (i subtracted this in testing - the pokeball flew into the sky and disappeared)
                }
            }
            else if (Projectile.ai[1] == 2)
            {
                Projectile.rotation += rotationVelocity;
                if (Projectile.ai[0] >= 75 * speedMultiply)
                {
                    //Main.NewText(catchTries, Color.CornflowerBlue);
                    if (catchTries == 0 || TerramonMod.fastAnimations)
                    {
                        if (caught)
                        {
                            Projectile.frame = (int)Frame.CaptureComplete;
                            SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_catch"), Projectile.position);
                            Projectile.ai[1] = 3;
                            Projectile.ai[0] = 0;
                        }
                        else
                        {
                            ReleasePokemon();
                            Projectile.Kill();
                        }
                    }
                    else
                    {
                        catchTries -= 1;
                        rotationVelocity = 0.2f;
                        SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_shake"), Projectile.position);
                    }
                    Projectile.ai[0] = 0;
                }
                else if (Math.Abs(Projectile.rotation) < 0.1f)
                {
                    Projectile.rotation = 0;
                    rotationVelocity = 0;
                }
                else if (rotationVelocity > -0.2f)
                    rotationVelocity -= 0.05f;

            }
            else if (Projectile.ai[1] == 3)
            {  
                if (Projectile.ai[0] == 1)
                    for (int i = 0; i < 3; i++)
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
                if (Projectile.ai[0] >= 90f * speedMultiply)
                    PokemonCatchSuccess();
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = 0;
            //if (capture == null)
                //Main.NewText($"{target.ModNPC != null}, {target.ModNPC is BasePkmn}, {((BasePkmn)target.ModNPC).catchable}");

            if (capture == null && (target.ModNPC != null && target.ModNPC is BasePkmn && ((BasePkmn)target.ModNPC).catchable))
                HitPkmn(target);
        }

        public virtual bool CatchPokemonChances(BasePkmn capture, float random)
        {
            catchModifier = ChangeCatchModifier(capture); //Change modifier (can take into account values like pokemon type)

            float catchChance = capture.info.captureRate * 0.85f; //would / 3 to match game but we can't damage pokemon so that would be too hard
            //Main.NewText($"chance {catchChance * catchModifier}, random {random}");
            if (catchRandom < catchChance * catchModifier)
                return true;

            var split = (1 - catchChance) / 4;  //Determine amount of times pokeball will rock (based on closeness to successful catch)

            if (random < catchChance + (split * 1))
                catchTries = 3;
            else if (random < catchChance + (split * 2))
                catchTries = 2;
            else if (random < catchChance + (split * 3))
                catchTries = 1;
            else
                catchTries = 0;

            return false;
        }

        public virtual float ChangeCatchModifier(BasePkmn capture)
        {
            return catchModifier;
        }


        public void PokemonCatchSuccess()
        {
            var newItem = Item.NewItem(this.Entity.GetSource_DropAsItem(), Main.player[Projectile.owner].position, pokeballCapture);
            var newPkball = Main.item[newItem].ModItem as BasePkballItem;
            newPkball.SetContents(new PkmnData { pkmn = capture.GetType().Name, level = capture.level, isShiny = capture.isShiny });
            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem, 1f);
            //item.hold.Nickname = "Keffreye";


            SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkball_catch_pla"));
            Main.NewText($"Congratulations! You caught a level {capture.level} {capture.info.Name}", Color.Orange);
            Projectile.Kill();
        }

        public void HitPkmn(NPC target)
        {
            hasContainedLocal = true;
            //Main.NewText($"Contain success", Color.Orange);
            capture = (BasePkmn)target.ModNPC;

            Projectile.ai[1] = 1;
            Projectile.ai[0] = 0;
            if (!TerramonMod.fastAnimations)
                bounces = 5; //If fast animation disabled, reset bounces to 5 (so the animation isn't shorter if it's already hit the ground)
            else if (bounces > 2)
                bounces = 2;

            rotation = (target.Center - Projectile.Center).SafeNormalize(Vector2.Zero).ToRotation(); //Rotate to face Pokemon

            if (Math.Abs(rotation) > 1.5) //Stuff to make sure Pokeball doesn't appear upside down or reversed
            {
                if (rotation > 0)
                    rotation -= 3;
                else
                    rotation += 3;

                Projectile.spriteDirection = 1;
            }
            else
                Projectile.spriteDirection = -1;
            Projectile.netUpdate = true;
        }

        public void ReleasePokemon()
        {
            if (capture != null)
            {
                SoundEngine.PlaySound(new SoundStyle("TerramonMod/Sounds/pkmn_spawn"), Projectile.position);
                IEntitySource source = Entity.GetSource_FromThis();

                NPC e = new NPC();
                var newNPC = NPC.NewNPC(source, (int)Projectile.Center.X, (int)Projectile.Center.Y, capture.Type); // spawn a new NPC at the new position
                var newPoke = (BasePkmn)Main.npc[newNPC].ModNPC;
                newPoke.catchAttempts = capture.catchAttempts + 1;
                //Main.NewText($"Catch attempts: {newPoke.catchAttempts}", Color.Firebrick);
                capture = null;
            }
        }

        //public override bool? CanDamage() => false;

        // Finding the closest NPC to attack within maxDetectDistance range
        // If not found then returns null
        /*public NPC FindValidPokemon(float maxDetectDistance)
        {
            //Main.NewText($"NPC count: {Main.maxNPCs}");
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.ModNPC != null && target.ModNPC.GetType().BaseType == typeof(BasePkmn))
                {
                    Main.NewText($"Found {target.ModNPC.GetType().BaseType}", Color.Orange);

                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
                //Main.NewText(target.FullName, Color.Orange);
            }

            return closestNPC;
        }*/
    }
}
