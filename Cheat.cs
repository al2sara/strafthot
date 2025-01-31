using strafthot.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace strafthot
{
    public class Cheat : MonoBehaviour
    {
        private Cache _cache = new Cache(1);
        private Misc _misc = new Misc();
        private Vector2 _watermarkPos = new Vector2(10, 10);

        private bool _menuOpen = true;
        private Rect _windowRect = new Rect(100, 100, 400, 750);
        public Cache Cache { get => _cache; }
        public Misc Misc { get => _misc; }
        public static Cheat Instance { get; private set; }

        private void Awake()
        {


            if (Instance != null)
                Destroy(this);
            else
                Instance = this;

            Instance = this;
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Insert))
                _menuOpen = !_menuOpen;

            Cache.Update();

            WeaponMods.Update();
            _misc.Update();
            
        }

        private void Menu(int id)
        {
            Config.Instance.Draw();
            GUI.DragWindow();
        }

        private void OnGUI()
        {
            if (_menuOpen)
                _windowRect = GUI.Window(0, _windowRect, Menu, "strafthot - STRAFTAT menu");

            ESP.OnGUI();
        }
    }
}
