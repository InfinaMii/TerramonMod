using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ClefairyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Clefairy";

        public override float commodity => 1f;

        public override PkmnInfo info => ClefairyInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ClefairyInfo = new PkmnInfo
        {
            Name = "Clefairy",
            type1 = PkmnType.fairy,
            type2 = null,
            captureRate = (float)150 / 255,
            petType = ModContent.ProjectileType<ClefairyPet>(),
            evolveInto = "ClefairyNPC",
            evolveAt = -1
        };
    }

    class ClefairyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Clefairy";
	    public override bool doesFly => false;
    }
}
