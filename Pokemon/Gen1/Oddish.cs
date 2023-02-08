using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class OddishNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Oddish";

        public override float commodity => 1f;

        public override PkmnInfo info => OddishInfo;

        public override int wildLevel => 0;

        public static PkmnInfo OddishInfo = new PkmnInfo
        {
            Name = "Oddish",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<OddishPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class OddishPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Oddish";
    }
}
