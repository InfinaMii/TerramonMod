using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class FlareonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Flareon";

        public override float commodity => 1f;

        public override PkmnInfo info => FlareonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo FlareonInfo = new PkmnInfo
        {
            Name = "Flareon",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<FlareonPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class FlareonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Flareon";
    }
}
