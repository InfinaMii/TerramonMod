using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MachokeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machoke";

        public override float commodity => 1f;

        public override PkmnInfo info => MachokeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MachokeInfo = new PkmnInfo
        {
            Name = "Machoke",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<MachokePet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = "LinkCable",
                    level = null,
                    pokemon = "MachampNPC"
                }}
        };
    }

    class MachokePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Machoke";
	    public override bool doesFly => false;
    }
}
