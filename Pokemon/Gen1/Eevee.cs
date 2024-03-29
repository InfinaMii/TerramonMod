using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class EeveeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Eevee";

        public override float commodity => 1f;

        public override PkmnInfo info => EeveeInfo;

        public override int wildLevel => 0;

        public static PkmnInfo EeveeInfo = new PkmnInfo
        {
            Name = "Eevee",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<EeveePet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = "WaterStone",
                    level = null,
                    pokemon = "VaporeonNPC"
                },
                new PkmnEvo
                {
                    item = "ThunderStone",
                    level = null,
                    pokemon = "JolteonNPC"
                },
                new PkmnEvo
                {
                    item = "FireStone",
                    level = null,
                    pokemon = "FlareonNPC"
                }}
        };
    }

    class EeveePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Eevee";
	    public override bool doesFly => false;
    }
}
