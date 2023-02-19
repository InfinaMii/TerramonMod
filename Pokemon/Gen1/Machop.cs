using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MachopNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machop";

        public override float commodity => 1f;

        public override PkmnInfo info => MachopInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MachopInfo = new PkmnInfo
        {
            Name = "Machop",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)180 / 255,
            petType = ModContent.ProjectileType<MachopPet>(),
            evolveInto = "MachokeNPC",
            evolveAt = 28
        };
    }

    class MachopPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machop";
	    public override bool doesFly => false;
    }
}
