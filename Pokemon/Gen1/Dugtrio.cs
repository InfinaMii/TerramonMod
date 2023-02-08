using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DugtrioNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dugtrio";

        public override float commodity => 1f;

        public override PkmnInfo info => DugtrioInfo;

        public override int wildLevel => 1;

        public static PkmnInfo DugtrioInfo = new PkmnInfo
        {
            Name = "Dugtrio",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)50 / 255,
            petType = ModContent.ProjectileType<DugtrioPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class DugtrioPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dugtrio";
    }
}
