using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MetapodNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Metapod";

        public override float commodity => 1f;

        public override PkmnInfo info => MetapodInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MetapodInfo = new PkmnInfo
        {
            Name = "Metapod",
            type1 = PkmnType.bug,
            type2 = null,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<MetapodPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 10,
                    pokemon = "ButterfreeNPC"
                }}
        };
    }

    class MetapodPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Metapod";
	    public override bool doesFly => false;
    }
}
