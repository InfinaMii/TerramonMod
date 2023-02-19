using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KabutoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kabuto";

        public override float commodity => 1f;

        public override PkmnInfo info => KabutoInfo;

        public override int wildLevel => 0;

        public static PkmnInfo KabutoInfo = new PkmnInfo
        {
            Name = "Kabuto",
            type1 = PkmnType.rock,
            type2 = PkmnType.water,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<KabutoPet>(),
            evolveInto = "KabutopsNPC",
            evolveAt = 40
        };
    }

    class KabutoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kabuto";
	    public override bool doesFly => false;
    }
}
