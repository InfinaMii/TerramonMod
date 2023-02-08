using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SeadraNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seadra";

        public override float commodity => 1f;

        public override PkmnInfo info => SeadraInfo;

        public override int wildLevel => 1;

        public static PkmnInfo SeadraInfo = new PkmnInfo
        {
            Name = "Seadra",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<SeadraPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class SeadraPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seadra";
    }
}
