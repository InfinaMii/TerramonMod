using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidoranFNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/NidoranF";

        public override float commodity => 1f;

        public override PkmnInfo info => NidoranFInfo;

        public override int wildLevel => 0;

        public static PkmnInfo NidoranFInfo = new PkmnInfo
        {
            Name = "Nidoran♀",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)235 / 255,
            petType = ModContent.ProjectileType<NidoranFPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 16,
                    pokemon = "NidorinaNPC"
                }}
        };
    }

    class NidoranFPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/NidoranF";
	    public override bool doesFly => false;
    }
}
