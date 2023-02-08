using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class TentacoolNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tentacool";

        public override float commodity => 1f;

        public override PkmnInfo info => TentacoolInfo;

        public override int wildLevel => 0;

        public static PkmnInfo TentacoolInfo = new PkmnInfo
        {
            Name = "Tentacool",
            type1 = PkmnType.water,
            type2 = PkmnType.poison,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<TentacoolPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class TentacoolPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tentacool";
    }
}
