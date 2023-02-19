using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DoduoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Doduo";

        public override float commodity => 1f;

        public override PkmnInfo info => DoduoInfo;

        public override int wildLevel => 0;

        public static PkmnInfo DoduoInfo = new PkmnInfo
        {
            Name = "Doduo",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<DoduoPet>(),
            evolveInto = "DodrioNPC",
            evolveAt = 31
        };
    }

    class DoduoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Doduo";
	    public override bool doesFly => false;
    }
}
