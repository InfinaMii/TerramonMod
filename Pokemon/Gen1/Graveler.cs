using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GravelerNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Graveler";

        public override float commodity => 1f;

        public override PkmnInfo info => GravelerInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GravelerInfo = new PkmnInfo
        {
            Name = "Graveler",
            type1 = PkmnType.rock,
            type2 = PkmnType.ground,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<GravelerPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GravelerPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Graveler";
    }
}
