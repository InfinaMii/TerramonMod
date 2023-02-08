using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class AerodactylNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Aerodactyl";

        public override float commodity => 1f;

        public override PkmnInfo info => AerodactylInfo;

        public override int wildLevel => 0;

        public static PkmnInfo AerodactylInfo = new PkmnInfo
        {
            Name = "Aerodactyl",
            type1 = PkmnType.rock,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<AerodactylPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class AerodactylPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Aerodactyl";
    }
}
