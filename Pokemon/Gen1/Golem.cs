using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GolemNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golem";

        public override float commodity => 1f;

        public override PkmnInfo info => GolemInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GolemInfo = new PkmnInfo
        {
            Name = "Golem",
            type1 = PkmnType.rock,
            type2 = PkmnType.ground,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<GolemPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GolemPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golem";
    }
}
