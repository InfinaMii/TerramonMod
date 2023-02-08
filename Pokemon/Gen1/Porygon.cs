using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PorygonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Porygon";

        public override float commodity => 1f;

        public override PkmnInfo info => PorygonInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PorygonInfo = new PkmnInfo
        {
            Name = "Porygon",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<PorygonPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class PorygonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Porygon";
    }
}
