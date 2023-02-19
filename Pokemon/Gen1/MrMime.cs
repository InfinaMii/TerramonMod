using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MrMimeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/MrMime";

        public override float commodity => 1f;

        public override PkmnInfo info => MrMimeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MrMimeInfo = new PkmnInfo
        {
            Name = "Mr. Mime",
            type1 = PkmnType.psychic,
            type2 = PkmnType.fairy,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<MrMimePet>(),
            evolveInto = "MrRimeNPC",
            evolveAt = 42
        };
    }

    class MrMimePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/MrMime";
	    public override bool doesFly => false;
    }
}
