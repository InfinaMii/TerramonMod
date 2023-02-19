using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ElectrodeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Electrode";

        public override float commodity => 1f;

        public override PkmnInfo info => ElectrodeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ElectrodeInfo = new PkmnInfo
        {
            Name = "Electrode",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<ElectrodePet>(),
            evolveInto = "ElectrodeNPC",
            evolveAt = -1
        };
    }

    class ElectrodePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Electrode";
	    public override bool doesFly => false;
    }
}
