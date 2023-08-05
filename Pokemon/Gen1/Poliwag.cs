using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PoliwagNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwag";

        public override float commodity => 1f;

        public override PkmnInfo info => PoliwagInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PoliwagInfo = new PkmnInfo
        {
            Name = "Poliwag",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<PoliwagPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 25,
                    pokemon = "PoliwhirlNPC"
                }}
        };
    }

    class PoliwagPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwag";
	    public override bool doesFly => false;
    }
}
