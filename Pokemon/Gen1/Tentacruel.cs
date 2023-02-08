using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class TentacruelNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tentacruel";

        public override float commodity => 1f;

        public override PkmnInfo info => TentacruelInfo;

        public override int wildLevel => 1;

        public static PkmnInfo TentacruelInfo = new PkmnInfo
        {
            Name = "Tentacruel",
            type1 = PkmnType.water,
            type2 = PkmnType.poison,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<TentacruelPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class TentacruelPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tentacruel";
    }
}
