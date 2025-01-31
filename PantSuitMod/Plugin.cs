using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using PantSuitMod.Patches;

namespace PantSuitMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class PantSuitModBase : BaseUnityPlugin
    {
        private const string modGUID = "MikamiStudio.PantSuitMod";
        private const string modName = "Pant Suit Mod";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static PantSuitModBase Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("PantSuitMod have started");

            harmony.PatchAll(typeof(PantSuitModBase));
            harmony.PatchAll(typeof(OutfitLogicPatch));
            harmony.PatchAll(typeof(EmoteSelectionPatch));
            harmony.PatchAll(typeof(HideBodyPartPatch));
        }
    }
}
