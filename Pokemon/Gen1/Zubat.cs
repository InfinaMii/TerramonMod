using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ZubatNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Zubat";

        public override float commodity => 1f;

        public override PkmnInfo info => ZubatInfo;

        public override int wildLevel => 0;

        public static PkmnInfo ZubatInfo = new PkmnInfo
        {
            Name = "Zubat",
            type1 = PkmnType.poison,
            type2 = PkmnType.flying,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<ZubatPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class ZubatPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Zubat";
    }
}
