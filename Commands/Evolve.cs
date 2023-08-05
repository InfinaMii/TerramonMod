using Microsoft.Xna.Framework;
using System.Diagnostics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerramonMod;
using TerramonMod.Items;

namespace TerramonMod.Commands
{
    internal class Evolve : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "evolve";

        public override string Description => "Evolve the currently summoned Pokemon.";

        public override string Usage => "/evolve";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            var pokemon = Main.player[Main.myPlayer].GetModPlayer<TerramonPlayer>().pokeInUse;

            if (pokemon == null)
            {
                Main.NewText("No Pokemon is summoned!", Color.Red);
                return;
            }
            else
            {
                var info = pokemon.data.GetInfo();
                var hasEvolved = pokemon.data.Evolve();

                if (!hasEvolved)
                {
                    if (info.evolutionMethods == null)
                    {
                        Main.NewText($"{info.Name}s don't evolve into anything!", Color.Red);
                        return;
                    }
                    else
                    {
                        Main.NewText($"Your Pokemon can't evolve yet!", Color.Red);
                        return;
                    }
                }
                else
                    pokemon.UpdateName();
            }

        }
    }
}