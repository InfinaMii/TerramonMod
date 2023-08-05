using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MankeyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Mankey";

        public override float commodity => 1f;

        public override PkmnInfo info => MankeyInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MankeyInfo = new PkmnInfo
        {
            Name = "Mankey",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<MankeyPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 28,
                    pokemon = "PrimeapeNPC"
                }}
        };
    }

    class MankeyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Mankey";
	    public override bool doesFly => false;
    }
}
