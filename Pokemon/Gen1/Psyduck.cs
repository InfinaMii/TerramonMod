using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PsyduckNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Psyduck";

        public override float commodity => 1f;

        public override PkmnInfo info => PsyduckInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PsyduckInfo = new PkmnInfo
        {
            Name = "Psyduck",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<PsyduckPet>(),
            evolveInto = "GolduckNPC",
            evolveAt = 33
        };
    }

    class PsyduckPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Psyduck";
	    public override bool doesFly => false;
    }
}
