using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class FarfetchdNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Farfetchd";

        public override float commodity => 1f;

        public override PkmnInfo info => FarfetchdInfo;

        public override int wildLevel => 0;

        public static PkmnInfo FarfetchdInfo = new PkmnInfo
        {
            Name = "Farfetch’d",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<FarfetchdPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class FarfetchdPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Farfetchd";
    }
}
