using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GastlyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gastly";

        public override float commodity => 1f;

        public override PkmnInfo info => GastlyInfo;

        public override int wildLevel => 0;

        public static PkmnInfo GastlyInfo = new PkmnInfo
        {
            Name = "Gastly",
            type1 = PkmnType.ghost,
            type2 = PkmnType.poison,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<GastlyPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 25,
                    pokemon = "HaunterNPC"
                }}
        };
    }

    class GastlyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gastly";
	    public override bool doesFly => false;
    }
}
