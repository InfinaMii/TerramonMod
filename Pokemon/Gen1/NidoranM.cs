using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidoranMNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/NidoranM";

        public override float commodity => 1f;

        public override PkmnInfo info => NidoranMInfo;

        public override int wildLevel => 0;

        public static PkmnInfo NidoranMInfo = new PkmnInfo
        {
            Name = "Nidoran♂",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)235 / 255,
            petType = ModContent.ProjectileType<NidoranMPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 16,
                    pokemon = "NidorinoNPC"
                }}
        };
    }

    class NidoranMPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/NidoranM";
	    public override bool doesFly => false;
    }
}
