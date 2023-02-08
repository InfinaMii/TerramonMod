using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class FearowNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Fearow";

        public override float commodity => 1f;

        public override PkmnInfo info => FearowInfo;

        public override int wildLevel => 1;

        public static PkmnInfo FearowInfo = new PkmnInfo
        {
            Name = "Fearow",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<FearowPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class FearowPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Fearow";
    }
}
