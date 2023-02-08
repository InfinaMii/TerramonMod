using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MachampNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machamp";

        public override float commodity => 1f;

        public override PkmnInfo info => MachampInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MachampInfo = new PkmnInfo
        {
            Name = "Machamp",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<MachampPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class MachampPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machamp";
    }
}
