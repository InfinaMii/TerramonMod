using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ClefableNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Clefable";

        public override float commodity => 1f;

        public override PkmnInfo info => ClefableInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ClefableInfo = new PkmnInfo
        {
            Name = "Clefable",
            type1 = PkmnType.fairy,
            type2 = null,
            captureRate = (float)25 / 255,
            petType = ModContent.ProjectileType<ClefablePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class ClefablePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Clefable";
    }
}
