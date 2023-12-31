﻿using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;

namespace NWAPI_Essentials.Events
{
    internal class GodmodeforTutorial
    {
        [PluginConfig]
        public Config Config;

        [PluginEvent(ServerEventType.PlayerChangeRole)]
        public void ChangeRole(Player player, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
        {
            if (newRole == RoleTypeId.Tutorial)
            {
                player.IsGodModeEnabled = true;
            }
            else
                player.IsGodModeEnabled = false;
        }
    }
}
