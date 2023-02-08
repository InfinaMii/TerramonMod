using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PrimeapeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Primeape";

        public override float commodity => 1f;

        public override PkmnInfo info => PrimeapeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PrimeapeInfo = new PkmnInfo
        {
            Name = "Primeape",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<PrimeapePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class PrimeapePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Primeape";
    }
}
