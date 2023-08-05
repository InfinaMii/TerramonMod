using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PidgeyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgey";

        public override float commodity => 1f;

        public override PkmnInfo info => PidgeyInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PidgeyInfo = new PkmnInfo
        {
            Name = "Pidgey",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<PidgeyPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 18,
                    pokemon = "PidgeottoNPC"
                }}
        };
    }

    class PidgeyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgey";
	    public override bool doesFly => false;
    }
}
