using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TerramonMod.Pokemon
{
	public class PkmnBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) { // This method gets called every frame your buff is active on your player.

			if (player.GetModPlayer<TerramonPlayer>().usePokePet == -1) //if no pokemon exists then remove buff
			{
				//player.ClearBuff(buffIndex);
				player.buffTime[buffIndex] = 0;
				return;
			}
			else
				player.buffTime[buffIndex] = 18000;

			var pokePet = player.GetModPlayer<TerramonPlayer>().usePokePet;

			// If there hasn't been a pet projectile spawned yet - spawn it.
			if (player.ownedProjectileCounts[pokePet] <= 0) {
				var entitySource = player.GetSource_Buff(buffIndex);
				
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, pokePet, 0, 0f, player.whoAmI);
			}
		}
    }
}
