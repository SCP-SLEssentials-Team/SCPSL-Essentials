﻿using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;

namespace NWAPI_Essentials.Events
{
    internal class BCreport
    {
        [PluginConfig]
        public Config Config;

        [PluginEvent(ServerEventType.PlayerReport)]
        public void Report(Player ply, Player ply2, string reason)
        {
            if (ply != null && ply2 != null)
            {
                foreach (Player p in Player.GetPlayers())
                {
                    if (p.RemoteAdminAccess == true)
                    {
                        if (Config.language == "en")
                        {
                            p.SendBroadcast($"<color=red> {ply.Nickname} <color=yellow> Reported on</color> <color=red> {ply2.Nickname} </color><color=yellow>for</color> <color=red> {reason}", 9);
                        }
                        else
                        {
                            p.SendBroadcast($"<color=red> {ply.Nickname} <color=yellow> Пожаловался на on</color> <color=red> {ply2.Nickname} </color><color=yellow>за</color> <color=red> {reason}", 9);
                        }
                    }
                    else
                    {
                        Log.Debug("Error");
                    }
                }
            }
            else
            {
                Log.Debug("One or both players are null");
            }
        }
    }
}