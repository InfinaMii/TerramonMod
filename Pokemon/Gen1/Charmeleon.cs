using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CharmeleonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charmeleon";

        public override float commodity => 1f;

        public override PkmnInfo info => CharmeleonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo CharmeleonInfo = new PkmnInfo
        {
            Name = "Charmeleon",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<CharmeleonPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class CharmeleonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charmeleon";
    }
}
