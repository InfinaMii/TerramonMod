using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class WartortleNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Wartortle";

        public override float commodity => 1f;

        public override PkmnInfo info => WartortleInfo;

        public override int wildLevel => 1;

        public static PkmnInfo WartortleInfo = new PkmnInfo
        {
            Name = "Wartortle",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<WartortlePet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = null,
                    level = 36,
                    pokemon = "BlastoiseNPC"
                }}
        };
    }

    class WartortlePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Wartortle";
	    public override bool doesFly => false;
    }
}
