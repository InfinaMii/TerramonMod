using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RhyhornNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rhyhorn";

        public override float commodity => 1f;

        public override PkmnInfo info => RhyhornInfo;

        public override int wildLevel => 0;

        public static PkmnInfo RhyhornInfo = new PkmnInfo
        {
            Name = "Rhyhorn",
            type1 = PkmnType.ground,
            type2 = PkmnType.rock,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<RhyhornPet>(),
            evolveInto = "RhydonNPC",
            evolveAt = 42
        };
    }

    class RhyhornPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rhyhorn";
	    public override bool doesFly => false;
    }
}
