using Microsoft.Xna.Framework;
using System.Diagnostics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerramonMod;
using TerramonMod.Items;
using TerramonMod.Pokemon;

namespace TerramonMod.Commands.Developer
{
    internal class MakeShiny : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "makeshiny";

        public override string Description => "Switches the current pokemon into its Shiny form";

        public override string Usage => "/levelup";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            var pokemon = Main.player[Main.myPlayer].GetModPlayer<TerramonPlayer>().pokeInUse;

            if (pokemon != null)
            {
                pokemon.data.isShiny = !pokemon.data.isShiny;
                Main.NewText($"Changed the shiny state of {pokemon.data.GetName()}.", Color.Lime);
            }
            else
                Main.NewText("No Pokemon is summoned!", Color.Red);

        }
    }
}