using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Beam;

namespace StrandardDeep_Cheat
{
    public class Main : MonoBehaviour
    {
        public static bool AdvancedGodMode { private get; set; }

        // Token: 0x06000031 RID: 49 RVA: 0x000036E0 File Offset: 0x000018E0
        private static void SwitchMode()
        {
            Singleton<DeveloperMode>.Instance.SwitchModes();
            Singleton<DeveloperMode>.Instance.startInFlyMode = !Singleton<DeveloperMode>.Instance.InFlyMode;
            if (Singleton<DeveloperMode>.Instance.startInFlyMode)
            {
                Shader.SetGlobalFloat("_BelowVisibility", 100f);
            }
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.TERRAIN_OBJECTS, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.TERRAIN, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.INTERACTIVE_TREES, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.INTERACTIVE_OBJECTS, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS_SMALL, true);
            Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS_RAFTS, true);


        }

        private void Initialize()
        {
            
        }
        private void Awake()
        {
            this.toggles = base.GetComponentsInChildren<Toggle>();
            this.Initialize();
        }

        private void Start()
        {
            
        }
        private void Update()
        {
            if (Menu.NoClip)
            {
                if (Input.GetKey(KeyCode.F1))
                {
                    Main.SwitchMode();
                }
            }
            else
            {
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.TERRAIN_OBJECTS, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.TERRAIN, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.INTERACTIVE_TREES, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.INTERACTIVE_OBJECTS, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS_SMALL, false);
                Physics.IgnoreLayerCollision(Layers.PLAYER, Layers.CONSTRUCTIONS_RAFTS, false);
            }
           
           if ( Menu.InfiniteOxygen)
            {
                if (Game.State == GameState.MAIN_MENU)
                {
                    return;
                }
                if (Singleton<CetoSettings>.Instance == null)
                {
                    return;
                }
                if (PlayerRegistry.LocalPlayer == null)
                {
                    return;
                }
                if (PlayerRegistry.LocalPlayer.Movement == null)
                {
                    return;
                }
                if (!PlayerRegistry.LocalPlayer.Movement.inWater)
                {
                    return;
                }
                float num = UnityEngine.Random.Range(16f, 20f);
                if (PlayerRegistry.LocalPlayer.Statistics.Oxygen < PlayerRegistry.LocalPlayer.Statistics.MaxOxygen - num && PlayerRegistry.LocalPlayer.Movement.IsUnderwater && !PlayerRegistry.LocalPlayer.Movement.isFloating)
                {
                    PlayerRegistry.LocalPlayer.Statistics.AddOxygen(num);
                }
            }
           if (Input.GetKey(KeyCode.F12))
            {
                Loader.Unload();
            }

            if (this.DayTime)
            {
                if (Menu.DayTimeMultiplier == 1)
                {
                    this.toggles[0].isOn = true;
                    return;
                }
                if (Menu.DayTimeMultiplier == 2)
                {
                    this.toggles[1].isOn = true;
                    return;
                }
                if (Menu.DayTimeMultiplier == 3)
                {
                    this.toggles[2].isOn = true;
                    return;
                }
                if (Menu.DayTimeMultiplier == 4)
                {
                    this.toggles[3].isOn = true;
                    return;
                }
                if (Menu.DayTimeMultiplier == 5)
                {
                    this.toggles[4].isOn = true;
                    return;
                }
                if (Menu.DayTimeMultiplier == 6)
                {
                    this.toggles[5].isOn = true;
                    return;
                }
            }
            else
            {
                if (Menu.NightTimeMultiplier == 1)
                {
                    this.toggles[0].isOn = true;
                    return;
                }
                if (Menu.NightTimeMultiplier == 2)
                {
                    this.toggles[1].isOn = true;
                    return;
                }
                if (Menu.NightTimeMultiplier == 3)
                {
                    this.toggles[2].isOn = true;
                    return;
                }
                if (Menu.NightTimeMultiplier == 4)
                {
                    this.toggles[3].isOn = true;
                    return;
                }
                if (Menu.NightTimeMultiplier == 5)
                {
                    this.toggles[4].isOn = true;
                    return;
                }
                if (Menu.NightTimeMultiplier == 6)
                {
                    this.toggles[5].isOn = true;
                }
            }

        }
        
        private void FixedUpdate()
        {
            if (Menu.InfiniteHealth)
            {
                PlayerRegistry.LocalPlayer.Statistics.AddHealth(100);
            }
            if (Menu.InfiniteHunger)
            {
                PlayerRegistry.LocalPlayer.Statistics.Eat(InteractiveType.FOOD_CAN_BEANS, 1000);
            }
            if (Menu.InfiniteSleep)
            {
                PlayerRegistry.LocalPlayer.Statistics._sleep = 100;
            }
            if (Menu.GodMode)
            {
                PlayerRegistry.LocalPlayer.Statistics.Invincible = true;
            }
            else
            {
                PlayerRegistry.LocalPlayer.Statistics.Invincible = false;
            }

        }
        private void OnGUI()
        {
            
            if (Menu.Crosshair)
            {
                

                Render.DrawBox(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f - 7f), new Vector2(1,15), Color.yellow);
                Render.DrawBox(new Vector2((float)Screen.width / 2f - 7f, (float)Screen.height / 2f), new Vector2(15, 1), Color.yellow);
            }
        }

        public bool DayTime;

        // Token: 0x0400009F RID: 159
        private Toggle[] toggles;
    }
}

