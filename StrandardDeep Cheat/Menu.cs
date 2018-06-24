using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Beam.Events;
using Beam.UI;
using Beam;

namespace StrandardDeep_Cheat
{
    public class Menu : MonoBehaviour
    {
        // Token: 0x0600004A RID: 74 RVA: 0x00003B24 File Offset: 0x00001D24
        public void Start()
        {
            this._window = new Rect(10f, 10f, 250f, 150f);
            this._window2 = new Rect(10f, 10f, 250f, 150f);
            this._window3 = new Rect(10f, 10f, 250f, 150f);
            this._window4 = new Rect(10f, 10f, 250f, 150f);
        }

        // Token: 0x0600004B RID: 75 RVA: 0x00003B90 File Offset: 0x00001D90
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Home))
            {
                this.Visible = !this.Visible;
            }

        }

        // Token: 0x0600004C RID: 76 RVA: 0x00003BB0 File Offset: 0x00001DB0
        public void OnGUI()
        {
            if (!this.Visible)
            {
                return;
            }
            this._window = GUILayout.Window(0, this._window, new GUI.WindowFunction(this.Draw), "Stranded Deep (HOME)", new GUILayoutOption[0]);
            if (this.OptionsVisible)
            {
                this._window2 = GUILayout.Window(1, this._window2, new GUI.WindowFunction(this.DrawESPOptions), "Entity Options", new GUILayoutOption[0]);
            }
            if (this.ItemsVisible)
            {
                this._window3 = GUILayout.Window(2, this._window3, new GUI.WindowFunction(this.DrawAvailablePickups), "Loot options", new GUILayoutOption[0]);
            }
            if (this.OtherVisible)
            {
                this._window4 = GUILayout.Window(3, this._window4, new GUI.WindowFunction(this.DrawOtherOptions), "Other options", new GUILayoutOption[0]);
            }
        }

        public void Draw(int id)
        {
            Menu.LootESP = GUILayout.Toggle(Menu.LootESP, "Loot ESP", new GUILayoutOption[0]);
            GUILayout.Label(string.Format("Loot Distance: {0}", Menu.LoopDist), new GUILayoutOption[0]);
            Menu.LoopDist = Mathf.Round(GUILayout.HorizontalSlider(Menu.LoopDist, 0f, 5000f, new GUILayoutOption[0]) * 5000f) / 5000f;
            Menu.EntityESP = GUILayout.Toggle(Menu.EntityESP, "Entity ESP", new GUILayoutOption[0]);
            GUILayout.Label(string.Format("Entity Distance: {0}", Menu.EntityDist), new GUILayoutOption[0]);
            Menu.EntityDist = Mathf.Round(GUILayout.HorizontalSlider(Menu.EntityDist, 0f, 5000f, new GUILayoutOption[0]) * 5000f) / 5000f;
            GUILayout.Space(10f);
            Menu.Crosshair = GUILayout.Toggle(Menu.Crosshair, "CrossHair", new GUILayoutOption[0]);
            Menu.NoClip = GUILayout.Toggle(Menu.NoClip, "No Clip (F1 Switch modes)", new GUILayoutOption[0]);
            Menu.InfiniteOxygen = GUILayout.Toggle(Menu.InfiniteOxygen, "Infinite Oxygen", new GUILayoutOption[0]);
            Menu.GodMode = GUILayout.Toggle(Menu.GodMode, "GodMode", new GUILayoutOption[0]);
            if (GUILayout.Button("Entity Options", new GUILayoutOption[0]))
            {
                this._window2.x = this._window.width + 20f;
                this.OptionsVisible = !this.OptionsVisible;
            }

            if (GUILayout.Button("Loot options", new GUILayoutOption[0]))
            {
                this._window3.x = this._window2.width + 300f;
                this.ItemsVisible = !this.ItemsVisible;
            }
            if (GUILayout.Button("Other options", new GUILayoutOption[0]))
            {
                this._window4.x = this._window3.width + 20f;
                this._window4.y = this._window3.width + 100f;
                this.OtherVisible = !this.OtherVisible;
            }
            if (GUILayout.Button("Unload", new GUILayoutOption[0]))
            {
                Loader.Unload();
            }
            GUI.DragWindow();
        }

        public void DrawOtherOptions(int id)
        {
            GUILayout.Label("Other Options:", new GUILayoutOption[0]);
            GUILayout.Space(-5f);
            GUILayout.Label(string.Format("Day Time Multiplier: {0}", Menu.DayTimeMultiplier), new GUILayoutOption[0]);
            Menu.DayTimeMultiplier = (int)(GUILayout.HorizontalSlider((int)DayTimeMultiplier, (int)0, (int)6, new GUILayoutOption[(int)0]) * (int)6 / (int)6);

            GUILayout.Label(string.Format("Night Time Multiplier: {0}", Menu.NightTimeMultiplier), new GUILayoutOption[0]);
            Menu.NightTimeMultiplier = (int)(GUILayout.HorizontalSlider((int)NightTimeMultiplier, (int)0, (int)6, new GUILayoutOption[(int)0]) * (int)6 / (int)6);
            GUILayout.Space(-5f);
            Menu.MissionBoardsESP = GUILayout.Toggle(Menu.MissionBoardsESP, "Mission Boards", new GUILayoutOption[0]);

            Menu.InfiniteHealth = GUILayout.Toggle(Menu.InfiniteHealth, "Infinite Health", new GUILayoutOption[0]);
            Menu.InfiniteHunger = GUILayout.Toggle(Menu.InfiniteHunger, "Infinite Hunger", new GUILayoutOption[0]);
            Menu.InfiniteWater = GUILayout.Toggle(Menu.InfiniteWater, "Infinite Water", new GUILayoutOption[0]);
            Menu.InfiniteSleep = GUILayout.Toggle(Menu.InfiniteSleep, "Infinite Sleep", new GUILayoutOption[0]);

            GUI.DragWindow();

        }

        public void DrawESPOptions(int id)
        {
            GUILayout.Label("Entity Options:", new GUILayoutOption[0]);
            GUILayout.Space(-5f);
            Menu.CrabESP = GUILayout.Toggle(Menu.CrabESP, "Crab", new GUILayoutOption[0]);
            Menu.BirdESP = GUILayout.Toggle(Menu.BirdESP, "Bird", new GUILayoutOption[0]);
            Menu.FishESP = GUILayout.Toggle(Menu.FishESP, "Fishes", new GUILayoutOption[0]);
            Menu.sharkESP = GUILayout.Toggle(Menu.sharkESP, "Sharks", new GUILayoutOption[0]);
            Menu.SkinnableESP = GUILayout.Toggle(Menu.SkinnableESP, "Skinnable", new GUILayoutOption[0]);
            Menu.WhaleESP = GUILayout.Toggle(Menu.WhaleESP, "Whale", new GUILayoutOption[0]);
            Menu.BoarESP = GUILayout.Toggle(Menu.BoarESP, "Boar", new GUILayoutOption[0]);
            GUI.DragWindow();
        }


        public void DrawAvailablePickups(int id)
        {
            GUILayout.Label("Loot Options:", new GUILayoutOption[0]);
            GUILayout.Space(-5f);
            Menu.FoodESP = GUILayout.Toggle(Menu.FoodESP, "Food", new GUILayoutOption[0]);
            Menu.MiningRocksESP = GUILayout.Toggle(Menu.MiningRocksESP, "Mining Rocks", new GUILayoutOption[0]);
            Menu.RaftESP = GUILayout.Toggle(Menu.RaftESP, "Raft", new GUILayoutOption[0]);
            Menu.ResourcesESP = GUILayout.Toggle(Menu.ResourcesESP, "Resources", new GUILayoutOption[0]);
            Menu.FuelCanESP = GUILayout.Toggle(Menu.FuelCanESP, "Fuel Can", new GUILayoutOption[0]);
            GUI.DragWindow();
        }

        // Token: 0x04000032 RID: 50
        public bool Visible = true;

        // Token: 0x04000032 RID: 50
        public bool OptionsVisible = false;

        // Token: 0x04000032 RID: 50
        public bool ItemsVisible = false;

        // Token: 0x04000032 RID: 50
        public bool OtherVisible = false;

        // Token: 0x04000035 RID: 53
        private Rect _window;

        // Token: 0x04000036 RID: 54
        private Rect _window2;

        // Token: 0x04000037 RID: 55
        private Rect _window3;

        private Rect _window4;

        public static int DayTimeMultiplier = 0;
        public static int NightTimeMultiplier = 0;
        public static bool MissionBoardsESP = false;
        public static bool InfiniteHealth = false;
        public static bool InfiniteHunger = false;
        public static bool InfiniteWater = false;
        public static bool InfiniteSleep = false;

        public static bool CrabESP = false;
        public static bool BirdESP = false;
        public static bool FishESP = false;
        public static bool sharkESP = false;
        public static bool WhaleESP = false;
        public static bool SkinnableESP = false;
        public static bool BoarESP = false;

        public static bool ResourcesESP = false;
        public static bool FuelCanESP = false;
        public static bool RaftESP = false;
        public static bool MiningRocksESP = false;
        public static bool FoodESP = false;

        public static float LoopDist = 10;
        public static float EntityDist = 10;
        public static bool InfiniteOxygen = false;
        public static bool NoClip = false;
        public static bool GodMode = false;
        public static bool Crosshair = true;
        public static bool EntityESP = false;
        public static bool LootESP = false;
    }
}
