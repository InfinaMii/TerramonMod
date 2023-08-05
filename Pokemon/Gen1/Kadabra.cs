using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KadabraNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kadabra";

        public override float commodity => 1f;

        public override PkmnInfo info => KadabraInfo;

        public override int wildLevel => 1;

        public static PkmnInfo KadabraInfo = new PkmnInfo
        {
            Name = "Kadabra",
            type1 = PkmnType.psychic,
            type2 = null,
            captureRate = (float)100 / 255,
            petType = ModContent.ProjectileType<KadabraPet>(),
            evolutionMethods = new PkmnEvo[] {
                new PkmnEvo
                {
                    item = "LinkCable",
                    level = null,
                    pokemon = "AlakazamNPC"
                }}
        };
    }

    class KadabraPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kadabra";
	    public override bool doesFly => false;
    }
}
