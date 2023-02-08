using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MagikarpNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magikarp";

        public override float commodity => 1f;

        public override PkmnInfo info => MagikarpInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MagikarpInfo = new PkmnInfo
        {
            Name = "Magikarp",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<MagikarpPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class MagikarpPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magikarp";
    }
}
