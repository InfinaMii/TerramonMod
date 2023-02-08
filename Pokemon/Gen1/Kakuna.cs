using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KakunaNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kakuna";

        public override float commodity => 1f;

        public override PkmnInfo info => KakunaInfo;

        public override int wildLevel => 1;

        public static PkmnInfo KakunaInfo = new PkmnInfo
        {
            Name = "Kakuna",
            type1 = PkmnType.bug,
            type2 = PkmnType.poison,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<KakunaPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class KakunaPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kakuna";
    }
}
