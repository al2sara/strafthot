using strafthot.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace strafthot
{
    public class Config
    {
        public static Config Instance = new Config();
        private Vector2 _debugScrollPosition = Vector2.zero;
        private List<string> _debugLogs = new List<string>();
        private const int MAX_LOGS = 50;
        private bool _showDebugWindow = true;
        private bool _showCombat = true;
        private bool _showVisuals = true;
        private bool _showWeaponMods = true;
        private bool _showMisc = true;
        private bool _showDebug = true;

        public bool ESP = true;
        public bool InfiniteAmmo = false;
        public bool RapidFire = false;
        public bool InstaKill = false;
        public bool NoSpread = false;
        public bool Aimbot = false;
        public bool NoRecoil = false;
        public bool AutoShoot = false;
        public bool FlyMode = false;
        public bool GodMode = false;
        public bool MagicBullet = false;
        public bool FreezeEnemy = false;
        private GUIStyle _windowStyle;
        private GUIStyle _headerStyle;
        private GUIStyle _buttonStyle;
        private GUIStyle _toggleStyle;
        private GUIStyle _logStyle;

        private void InitializeStyles()
        {
            if (_windowStyle == null)
            {
                _windowStyle = new GUIStyle(GUI.skin.window);
                _windowStyle.normal.background = MakeTexture(2, 2, new Color(0.1f, 0.1f, 0.1f, 0.95f));
                _windowStyle.normal.textColor = Color.white;
                _windowStyle.fontSize = 14;
                _windowStyle.fontStyle = FontStyle.Bold;
                _headerStyle = new GUIStyle(GUI.skin.button);
                _headerStyle.normal.background = MakeTexture(2, 2, new Color(0.2f, 0.2f, 0.2f, 1));
                _headerStyle.hover.background = MakeTexture(2, 2, new Color(0.25f, 0.25f, 0.25f, 1));
                _headerStyle.normal.textColor = Color.cyan;
                _headerStyle.fontSize = 12;
                _headerStyle.fontStyle = FontStyle.Bold;
                _headerStyle.alignment = TextAnchor.MiddleLeft;
                _headerStyle.padding = new RectOffset(10, 10, 5, 5);
                _toggleStyle = new GUIStyle(GUI.skin.toggle);
                _toggleStyle.normal.textColor = Color.white;
                _toggleStyle.onNormal.textColor = Color.white;
                _toggleStyle.hover.textColor = Color.white;
                _toggleStyle.onHover.textColor = Color.white;
                _toggleStyle.fontSize = 12;
                _toggleStyle.padding = new RectOffset(20, 5, 5, 5);
                _toggleStyle.margin = new RectOffset(5, 5, 5, 5);
                _buttonStyle = new GUIStyle(GUI.skin.button);
                _buttonStyle.normal.background = MakeTexture(2, 2, new Color(0.2f, 0.2f, 0.2f, 1));
                _buttonStyle.hover.background = MakeTexture(2, 2, new Color(0.3f, 0.3f, 0.3f, 1));
                _buttonStyle.normal.textColor = Color.white;
                _buttonStyle.fontSize = 12;
                _logStyle = new GUIStyle(GUI.skin.label);
                _logStyle.normal.textColor = Color.white;
                _logStyle.fontSize = 11;
                _logStyle.wordWrap = true;
            }
        }

        private Texture2D MakeTexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = color;

            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }

        public void Draw()
        {
            InitializeStyles();

            GUILayout.BeginVertical(_windowStyle);
            GUILayout.Label("strafthot", new GUIStyle(GUI.skin.label) { 
                alignment = TextAnchor.MiddleCenter,
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                normal = { textColor = Color.cyan }
            });
            if (GUILayout.Button("Aimbot" + (_showCombat ? " [-]" : " [+]"), _headerStyle))
                _showCombat = !_showCombat;
            if (_showCombat)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                Aimbot = GUILayout.Toggle(Aimbot, "Aimbot [LEFT ALT]", _toggleStyle);
                AutoShoot = GUILayout.Toggle(AutoShoot, "Auto Shoot", _toggleStyle);
                GUILayout.EndVertical();
            }
            if (GUILayout.Button("Visuals" + (_showVisuals ? " [-]" : " [+]"), _headerStyle))
                _showVisuals = !_showVisuals;
            if (_showVisuals)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                ESP = GUILayout.Toggle(ESP, "ESP", _toggleStyle);
                GUILayout.EndVertical();
            }
            if (GUILayout.Button("Weapon Mods" + (_showWeaponMods ? " [-]" : " [+]"), _headerStyle))
                _showWeaponMods = !_showWeaponMods;
            if (_showWeaponMods)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                InfiniteAmmo = GUILayout.Toggle(InfiniteAmmo, "Infinite Ammo", _toggleStyle);
                InstaKill = GUILayout.Toggle(InstaKill, "Insta Kill", _toggleStyle);
                RapidFire = GUILayout.Toggle(RapidFire, "Rapid Fire", _toggleStyle);
                NoSpread = GUILayout.Toggle(NoSpread, "No Spread", _toggleStyle);
                GUILayout.EndVertical();
            }
            if (GUILayout.Button("Miscellaneous" + (_showMisc ? " [-]" : " [+]"), _headerStyle))
                _showMisc = !_showMisc;
            if (_showMisc)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                if (GUILayout.Button("Teleport to Enemy (Z)", _buttonStyle))
                {
                }
                FlyMode = GUILayout.Toggle(FlyMode, "Fly Hack", _toggleStyle);
                GodMode = GUILayout.Toggle(GodMode, "God Mode", _toggleStyle);
                MagicBullet = GUILayout.Toggle(MagicBullet, "Magic Bullet", _toggleStyle);
                FreezeEnemy = GUILayout.Toggle(FreezeEnemy, "Freeze Enemy", _toggleStyle);
                GUILayout.EndVertical();
            }
            if (GUILayout.Button("Debug Logs" + (_showDebug ? " [-]" : " [+]"), _headerStyle))
                _showDebug = !_showDebug;
            if (_showDebug)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                _debugScrollPosition = GUILayout.BeginScrollView(_debugScrollPosition, GUILayout.Height(100));
                foreach (string log in _debugLogs)
                {
                    GUILayout.Label(log, _logStyle);
                }
                GUILayout.EndScrollView();

                if (GUILayout.Button("Clear Logs", _buttonStyle))
                {
                    _debugLogs.Clear();
                }
                GUILayout.EndVertical();
            }

            GUILayout.EndVertical();
        }

        public void AddDebugLog(string message)
        {
            _debugLogs.Insert(0, $"[{Time.time:F1}] {message}");
            if (_debugLogs.Count > MAX_LOGS)
                _debugLogs.RemoveAt(_debugLogs.Count - 1);
        }
    }
}
