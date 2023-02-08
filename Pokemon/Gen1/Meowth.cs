using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MeowthNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Meowth";

        public override float commodity => 1f;

        public override PkmnInfo info => MeowthInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MeowthInfo = new PkmnInfo
        {
            Name = "Meowth",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<MeowthPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class MeowthPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Meowth";
    }
}
