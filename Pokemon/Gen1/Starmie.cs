using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class StarmieNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Starmie";

        public override float commodity => 1f;

        public override PkmnInfo info => StarmieInfo;

        public override int wildLevel => 1;

        public static PkmnInfo StarmieInfo = new PkmnInfo
        {
            Name = "Starmie",
            type1 = PkmnType.water,
            type2 = PkmnType.psychic,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<StarmiePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class StarmiePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Starmie";
    }
}
