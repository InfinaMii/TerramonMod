using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DodrioNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dodrio";

        public override float commodity => 1f;

        public override PkmnInfo info => DodrioInfo;

        public override int wildLevel => 1;

        public static PkmnInfo DodrioInfo = new PkmnInfo
        {
            Name = "Dodrio",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<DodrioPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class DodrioPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dodrio";
    }
}
