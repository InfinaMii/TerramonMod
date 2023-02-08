using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CaterpieNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Caterpie";

        public override float commodity => 1f;

        public override PkmnInfo info => CaterpieInfo;

        public override int wildLevel => 0;

        public static PkmnInfo CaterpieInfo = new PkmnInfo
        {
            Name = "Caterpie",
            type1 = PkmnType.bug,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<CaterpiePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class CaterpiePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Caterpie";
    }
}
