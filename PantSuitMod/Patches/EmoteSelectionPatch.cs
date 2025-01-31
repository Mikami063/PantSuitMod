using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace PantSuitMod.Patches
{
    [HarmonyPatch(typeof(EmoteSelection))]
    internal class EmoteSelectionPatch
    {
        [HarmonyPatch("CheckClothing")]
        [HarmonyPrefix]
        static bool CheckClothing(int emoteIndex)
        {
            PantSuitModBase.mls.LogInfo("CheckCloth disabled");
            return false;
        }
    }
}
