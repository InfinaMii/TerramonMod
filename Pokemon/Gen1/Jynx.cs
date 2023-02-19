using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class JynxNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jynx";

        public override float commodity => 1f;

        public override PkmnInfo info => JynxInfo;

        public override int wildLevel => 1;

        public static PkmnInfo JynxInfo = new PkmnInfo
        {
            Name = "Jynx",
            type1 = PkmnType.ice,
            type2 = PkmnType.psychic,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<JynxPet>(),
            evolveInto = "JynxNPC",
            evolveAt = -1
        };
    }

    class JynxPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jynx";
	    public override bool doesFly => false;
    }
}
