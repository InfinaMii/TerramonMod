using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VulpixNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vulpix";

        public override float commodity => 1f;

        public override PkmnInfo info => VulpixInfo;

        public override int wildLevel => 0;

        public static PkmnInfo VulpixInfo = new PkmnInfo
        {
            Name = "Vulpix",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<VulpixPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class VulpixPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vulpix";
    }
}
