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
    internal class LevelUp : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "levelup";

        public override string Description => "Give a nickname to the currently summoned Pokemon.";

        public override string Usage => "/levelup";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            var pokemon = Main.player[Main.myPlayer].GetModPlayer<TerramonPlayer>().pokeInUse;

            int levels = 1;
            if (args.Length > 0 && int.TryParse(args[0], out var parsedInt))
                levels = parsedInt;

            if (pokemon != null)
            {
                pokemon.data.LevelUp(levels);
                Main.NewText($"Added {levels} level(s) to {pokemon.data.GetName()}.", Color.Lime);
            }
            else
                Main.NewText("No Pokemon is summoned!", Color.Red);

        }
    }
}