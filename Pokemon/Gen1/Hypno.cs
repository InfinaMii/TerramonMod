using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class HypnoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hypno";

        public override float commodity => 1f;

        public override PkmnInfo info => HypnoInfo;

        public override int wildLevel => 1;

        public static PkmnInfo HypnoInfo = new PkmnInfo
        {
            Name = "Hypno",
            type1 = PkmnType.psychic,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<HypnoPet>(),
            evolutionMethods = null
        };
    }

    class HypnoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hypno";
	    public override bool doesFly => false;
    }
}
