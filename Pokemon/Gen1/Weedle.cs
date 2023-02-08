using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class WeedleNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weedle";

        public override float commodity => 1f;

        public override PkmnInfo info => WeedleInfo;

        public override int wildLevel => 0;

        public static PkmnInfo WeedleInfo = new PkmnInfo
        {
            Name = "Weedle",
            type1 = PkmnType.bug,
            type2 = PkmnType.poison,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<WeedlePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class WeedlePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weedle";
    }
}
