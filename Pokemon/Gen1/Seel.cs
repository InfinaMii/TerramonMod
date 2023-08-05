using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SeelNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seel";

        public override float commodity => 1f;

        public override PkmnInfo info => SeelInfo;

        public override int wildLevel => 0;

        public static PkmnInfo SeelInfo = new PkmnInfo
        {
            Name = "Seel",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<SeelPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 34,
                    pokemon = "DewgongNPC"
                }}
        };
    }

    class SeelPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seel";
	    public override bool doesFly => false;
    }
}
