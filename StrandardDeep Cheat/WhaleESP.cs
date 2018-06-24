using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Beam;
using Beam.AI;

namespace StrandardDeep_Cheat
{
    public class WhaleESP : MonoBehaviour
    {
        private void Start()
        {

        }
        IEnumerator SleepFor(float Time)
        {
            yield return new WaitForSeconds(Time);
        }

        Player localplayer = FindObjectsOfType<Player>()[0];
        private void OnGUI()
        {
            if (Menu.EntityESP == true)
            {
                if (Menu.SkinnableESP)
                {
                    IEnumerable<InteractiveObject_WHALE> playerProxies = FindObjectsOfType<InteractiveObject_WHALE>();
                    foreach (InteractiveObject_WHALE playerProxy in playerProxies)
                    {

                        Vector3 pos = playerProxy.transform.position;
                        Vector3 posScreen = Camera.main.WorldToScreenPoint(pos);

                        if (posScreen.z > 0 & posScreen.y < Screen.width - 2)
                        {
                            float dist = Vector3.Distance(pos, localplayer.transform.position);
                            if (dist < Menu.EntityDist)
                            {
                                posScreen.y = Screen.height - (posScreen.y + 1f);
                                Render.DrawString(new Vector2(posScreen.x, posScreen.y), ("   Whale" + string.Format(" [{0:0}m]", (object)dist)), Color.green);
                            }
                        }
                        SleepFor(0.300f);
                    }
                    SleepFor(0.300f);
                }
                SleepFor(0.300f);

            }
        }


        private void Update()
        {

        }
    }
}
