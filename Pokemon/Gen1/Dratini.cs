using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DratiniNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dratini";

        public override float commodity => 1f;

        public override PkmnInfo info => DratiniInfo;

        public override int wildLevel => 0;

        public static PkmnInfo DratiniInfo = new PkmnInfo
        {
            Name = "Dratini",
            type1 = PkmnType.dragon,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<DratiniPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 30,
                    pokemon = "DragonairNPC"
                }}
        };
    }

    class DratiniPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dratini";
	    public override bool doesFly => false;
    }
}
