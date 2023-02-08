using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VictreebelNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Victreebel";

        public override float commodity => 1f;

        public override PkmnInfo info => VictreebelInfo;

        public override int wildLevel => 1;

        public static PkmnInfo VictreebelInfo = new PkmnInfo
        {
            Name = "Victreebel",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<VictreebelPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class VictreebelPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Victreebel";
    }
}
