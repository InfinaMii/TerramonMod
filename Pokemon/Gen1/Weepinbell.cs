using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class WeepinbellNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weepinbell";

        public override float commodity => 1f;

        public override PkmnInfo info => WeepinbellInfo;

        public override int wildLevel => 1;

        public static PkmnInfo WeepinbellInfo = new PkmnInfo
        {
            Name = "Weepinbell",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<WeepinbellPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class WeepinbellPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weepinbell";
    }
}
