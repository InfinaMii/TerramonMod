using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PonytaNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ponyta";

        public override float commodity => 1f;

        public override PkmnInfo info => PonytaInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PonytaInfo = new PkmnInfo
        {
            Name = "Ponyta",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<PonytaPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 40,
                    pokemon = "RapidashNPC"
                }}
        };
    }

    class PonytaPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ponyta";
	    public override bool doesFly => false;
    }
}
