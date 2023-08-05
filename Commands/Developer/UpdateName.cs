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
    internal class UpdateName : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "updatename";

        public override string Description => "Update the current Pokemon's item name (DEBUG, DO NOT SHIP)";

        public override string Usage => "/updatename";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            var pokemon = Main.player[Main.myPlayer].GetModPlayer<TerramonPlayer>().pokeInUse;

            if (pokemon != null)
            {
                pokemon.UpdateName();
                Main.NewText($"Updated the item name of the currently summoned Pokemon.", Color.Lime);
            }
            else
                Main.NewText("No Pokemon is summoned!", Color.Red);

        }
    }
}