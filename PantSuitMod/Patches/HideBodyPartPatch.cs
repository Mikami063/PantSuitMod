using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace PantSuitMod.Patches
{
    [HarmonyPatch(typeof(HideBodyPart))]
    internal class HideBodyPartPatch
    {

        [HarmonyPatch("ToggleBlendshapeCheckOnActiveOutfit")]
        [HarmonyPostfix]
        static void ToggleBlendshapeCheckOnActiveOutfit(bool isActive, HideBodyPart __instance, Inventory_System ___roxiInventory)
        {
            var getActiveOutfitIndex = AccessTools.Method(typeof(HideBodyPart), "GetActiveOutfitIndex");
            int activeOutfitIndex = (int)getActiveOutfitIndex.Invoke(__instance, new object[] {  });
            if(activeOutfitIndex == 4) 
            {
                ___roxiInventory.naked_level = 2;

                GameObject pants = GameObject.Find("Roxi/PantSuit/Pants");

                PantSuitModBase.mls.LogInfo("Trying to find Pants");
                if (pants != null)
                {
                    pants.SetActive(false);
                    PantSuitModBase.mls.LogInfo("Pants disabled");
                }
            }
            
        }
    }
}
