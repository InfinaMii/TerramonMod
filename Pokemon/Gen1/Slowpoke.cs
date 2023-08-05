using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SlowpokeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Slowpoke";

        public override float commodity => 1f;

        public override PkmnInfo info => SlowpokeInfo;

        public override int wildLevel => 0;

        public static PkmnInfo SlowpokeInfo = new PkmnInfo
        {
            Name = "Slowpoke",
            type1 = PkmnType.water,
            type2 = PkmnType.psychic,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<SlowpokePet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 37,
                    pokemon = "SlowbroNPC"
                },
                new PkmnEvo
                {
                    item = "GalaricaCuff",
                    level = null,
                    pokemon = "SlowbroNPC"
                }}
        };
    }

    class SlowpokePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Slowpoke";
	    public override bool doesFly => false;
    }
}
