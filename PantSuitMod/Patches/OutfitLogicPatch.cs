using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace PantSuitMod.Patches
{
    [HarmonyPatch(typeof(OutfitLogic))]
    internal class OutfitLogicPatch
    {
        [HarmonyPatch("OnOutfitButtonClicked")]
        [HarmonyPrefix]
        static bool OnOutfitButtonClickedPrefix(int outfitIndex, OutfitLogic __instance, GameObject[] ___outfitPieces)
        {
            PantSuitModBase.mls.LogInfo("outfitPieces: " + outfitIndex);
            PantSuitModBase.mls.LogInfo("__outfitPieces: " + ___outfitPieces);
            for (int i = 0; i < ___outfitPieces.Length; i++)
            {
                PantSuitModBase.mls.LogInfo("__outfitPieces[each]: " + ___outfitPieces[i]);
            }
            
            var activateOutfit = AccessTools.Method(typeof(OutfitLogic), "ActivateOutfit");
            activateOutfit.Invoke(__instance,new object[] { outfitIndex });

            if (outfitIndex == 4)
            {
                GameObject pants = ___outfitPieces[4].transform.Find("Pants")?.gameObject;
                GameObject pants2 = GameObject.Find("Roxi/PantSuit/Pants");
                PantSuitModBase.mls.LogInfo("Trying to find Pants");
                if (pants != null)
                {
                    pants.SetActive(false);
                    PantSuitModBase.mls.LogInfo("Pants disabled");
                }
                if (pants2 != null)
                {
                    pants2.SetActive(false);
                    PantSuitModBase.mls.LogInfo("Pants disabled");
                }
            }
            return false;
        }

        [HarmonyPatch("ActivateOutfit")]
        [HarmonyPostfix]
        static void ActivateOutfitPostfix()
        {
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
