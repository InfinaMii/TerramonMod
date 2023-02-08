using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SpearowNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Spearow";

        public override float commodity => 1f;

        public override PkmnInfo info => SpearowInfo;

        public override int wildLevel => 0;

        public static PkmnInfo SpearowInfo = new PkmnInfo
        {
            Name = "Spearow",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<SpearowPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class SpearowPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Spearow";
    }
}
