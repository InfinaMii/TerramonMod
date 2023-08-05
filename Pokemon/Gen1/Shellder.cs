using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ShellderNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Shellder";

        public override float commodity => 1f;

        public override PkmnInfo info => ShellderInfo;

        public override int wildLevel => 0;

        public static PkmnInfo ShellderInfo = new PkmnInfo
        {
            Name = "Shellder",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<ShellderPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = "WaterStone",
                    level = null,
                    pokemon = "CloysterNPC"
                }}
        };
    }

    class ShellderPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Shellder";
	    public override bool doesFly => false;
    }
}
