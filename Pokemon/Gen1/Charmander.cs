using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CharmanderNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charmander";

        public override float commodity => 1f;

        public override PkmnInfo info => CharmanderInfo;

        public override int wildLevel => 0;

        public static PkmnInfo CharmanderInfo = new PkmnInfo
        {
            Name = "Charmander",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<CharmanderPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 16,
                    pokemon = "CharmeleonNPC"
                }}
        };
    }

    class CharmanderPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charmander";
	    public override bool doesFly => false;
    }
}
