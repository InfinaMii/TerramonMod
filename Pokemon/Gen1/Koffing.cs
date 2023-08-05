using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KoffingNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Koffing";

        public override float commodity => 1f;

        public override PkmnInfo info => KoffingInfo;

        public override int wildLevel => 0;

        public static PkmnInfo KoffingInfo = new PkmnInfo
        {
            Name = "Koffing",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<KoffingPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 35,
                    pokemon = "WeezingNPC"
                }}
        };
    }

    class KoffingPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Koffing";
	    public override bool doesFly => false;
    }
}
