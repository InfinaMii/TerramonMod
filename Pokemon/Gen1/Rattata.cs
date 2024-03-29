using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RattataNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rattata";

        public override float commodity => 1f;

        public override PkmnInfo info => RattataInfo;

        public override int wildLevel => 0;

        public static PkmnInfo RattataInfo = new PkmnInfo
        {
            Name = "Rattata",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<RattataPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 20,
                    pokemon = "RaticateNPC"
                },
                new PkmnEvo
                {
                    item = null,
                    level = 20,
                    pokemon = "RaticateNPC"
                }}
        };
    }

    class RattataPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rattata";
	    public override bool doesFly => false;
    }
}
