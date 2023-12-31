﻿using CommandSystem;
using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using RemoteAdmin;
using System;
using UnityEngine;

namespace NWAPI_Essentials
{
    internal class Cheatcheckpassed : ICommand
    {
        [PluginConfig]
        public Config Config;
        public static Cheatcheckpassed Instance { get; } = new Cheatcheckpassed();
        public string Command { get; } = "Cheatcheckpassed";
        public string[] Aliases { get; } = { "ccp" };
        public string Description { get; } = "Pass a cheatcheck";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.Overwatch))
            {
                response = "You don't have permission to use this command! (Permission name: Overwatch)";
                return false;
            }

            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "This command can only be used by players.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "You must specify a player ID to target.";
                return false;
            }

            bool parsed = int.TryParse(arguments.At(0), out int playerId);
            if (!parsed)
            {
                response = "Invalid player ID provided.";
                return false;
            }

            GameObject playerObject = Player.Get(playerId)?.GameObject;
            if (playerObject == null)
            {
                response = "No player found with that ID.";
                return false;
            }

            Player player = Player.Get(playerId);
            if (player != null)
            {
                player.SetRole(RoleTypeId.Spectator);
                player.SendBroadcast("Cheat Check Pass", 5);
            }

            response = "Player role changed to Spectator.";
            return true;
        }
    }
}

