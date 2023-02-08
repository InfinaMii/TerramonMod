using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RhydonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rhydon";

        public override float commodity => 1f;

        public override PkmnInfo info => RhydonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo RhydonInfo = new PkmnInfo
        {
            Name = "Rhydon",
            type1 = PkmnType.ground,
            type2 = PkmnType.rock,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<RhydonPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class RhydonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rhydon";
    }
}
