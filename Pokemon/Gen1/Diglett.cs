using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DiglettNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Diglett";

        public override float commodity => 1f;

        public override PkmnInfo info => DiglettInfo;

        public override int wildLevel => 0;

        public static PkmnInfo DiglettInfo = new PkmnInfo
        {
            Name = "Diglett",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<DiglettPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 26,
                    pokemon = "DugtrioNPC"
                }}
        };
    }

    class DiglettPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Diglett";
	    public override bool doesFly => false;
    }
}
