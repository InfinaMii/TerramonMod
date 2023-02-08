using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GeodudeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Geodude";

        public override float commodity => 1f;

        public override PkmnInfo info => GeodudeInfo;

        public override int wildLevel => 0;

        public static PkmnInfo GeodudeInfo = new PkmnInfo
        {
            Name = "Geodude",
            type1 = PkmnType.rock,
            type2 = PkmnType.ground,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<GeodudePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GeodudePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Geodude";
    }
}
