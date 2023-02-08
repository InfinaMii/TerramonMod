using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SquirtleNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Squirtle";

        public override float commodity => 1f;

        public override PkmnInfo info => SquirtleInfo;

        public override int wildLevel => 0;

        public static PkmnInfo SquirtleInfo = new PkmnInfo
        {
            Name = "Squirtle",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<SquirtlePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class SquirtlePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Squirtle";
    }
}
