using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HeathenEngineering.SteamworksIntegration;
using HeathenEngineering.SteamworksIntegration.API;

namespace strafthot.Features
{
    public class Misc
    {
        private void GodMode(PlayerHealth _localPlayer)
        {
            
            _localPlayer.sync___set_value_health(100f, _localPlayer.IsHost);
        }

        private void GodModeEnemy(PlayerHealth _enemyPlayer)
        {

            _enemyPlayer.sync___set_value_health(100f, true);
        }

        private readonly Cache _cache;

        public void Update()
        {
            PlayerCache _player = Cheat.Instance.Cache.LocalPlayer;

            if (Config.Instance.GodMode)
            {
                GodMode(_player.PlayerHealth);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.F5))
            {
                _cache.Settings.rocketJumpsHatAch.Unlock();
                _cache.Settings.windowsBrokenHatAch.Unlock();
                _cache.Settings.headshotHatAch.Unlock();
                _cache.Settings.ragdollsThrownAwayHatAch.Unlock();
                _cache.Settings.taserShotsHatAch.Unlock();
                _cache.Settings.noscopeHatAch.Unlock();
                _cache.Settings.potsBrokenHatAch.Unlock();
                _cache.Settings.fiveGamesHatAch.Unlock();
                _cache.Settings.killsHatAch.Unlock();
                _cache.Settings.propKillsHatAch.Unlock();
                StatsAndAchievements.Client.StoreStats();
                _cache.Settings.SteamAchievementsCheck();
            }

        }
    }
}
