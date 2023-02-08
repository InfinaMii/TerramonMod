using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class HorseaNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Horsea";

        public override float commodity => 1f;

        public override PkmnInfo info => HorseaInfo;

        public override int wildLevel => 0;

        public static PkmnInfo HorseaInfo = new PkmnInfo
        {
            Name = "Horsea",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)225 / 255,
            petType = ModContent.ProjectileType<HorseaPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class HorseaPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Horsea";
    }
}
