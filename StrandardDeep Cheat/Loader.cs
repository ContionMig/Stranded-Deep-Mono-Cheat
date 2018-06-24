using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StrandardDeep_Cheat
{
    // Token: 0x02000005 RID: 5
    public class Loader : MonoBehaviour
    {
        // Token: 0x06000019 RID: 25 RVA: 0x000027E8 File Offset: 0x000009E8
        public static void Load()
        {
            Loader._loadObject = new GameObject();
            Loader._loadObject.AddComponent<Main>();
            Loader._loadObject.AddComponent<Menu>();
            Loader._loadObject.AddComponent<CrabESP>();
            Loader._loadObject.AddComponent<BirdsESP>();
            Loader._loadObject.AddComponent<FishesESP>();
            Loader._loadObject.AddComponent<SharkESP>();
            Loader._loadObject.AddComponent<SkinnableESP>();
            Loader._loadObject.AddComponent<WhaleESP>();
            Loader._loadObject.AddComponent<FoodESP>();
            Loader._loadObject.AddComponent<MiningRocksESP>();
            Loader._loadObject.AddComponent<RaftESP>();
            Loader._loadObject.AddComponent<ResourcesHARVESTPLANTESP>();
            Loader._loadObject.AddComponent<ResourcesHARVESTRESOURCEESP>();
            Loader._loadObject.AddComponent<ResourcesPALM_LOGESP>();
            Loader._loadObject.AddComponent<FuelCanESP>();
            Loader._loadObject.AddComponent<BoarESP>();
            Loader._loadObject.AddComponent<MissionBoardsESP>();
            //Loader._loadObject.AddComponent<PickupESP>();
            GameObject.DontDestroyOnLoad(Loader._loadObject);
        }

        // Token: 0x0600001B RID: 27 RVA: 0x0000288C File Offset: 0x00000A8C
        public static void Unload()
        {
            Loader._Unload();
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002894 File Offset: 0x00000A94
        private static void _Unload()
        {
            GameObject.Destroy(Loader._loadObject);
        }

        // Token: 0x04000001 RID: 1
        public static GameObject _loadObject;
    }
}
