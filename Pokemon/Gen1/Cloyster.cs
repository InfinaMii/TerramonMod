using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CloysterNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Cloyster";

        public override float commodity => 1f;

        public override PkmnInfo info => CloysterInfo;

        public override int wildLevel => 1;

        public static PkmnInfo CloysterInfo = new PkmnInfo
        {
            Name = "Cloyster",
            type1 = PkmnType.water,
            type2 = PkmnType.ice,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<CloysterPet>(),
            evolveInto = "CloysterNPC",
            evolveAt = -1
        };
    }

    class CloysterPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Cloyster";
	    public override bool doesFly => false;
    }
}
