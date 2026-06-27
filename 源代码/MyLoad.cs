using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;

namespace BCSmartBattery
{
    internal class MyLoad : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary(true);
            base.OnLoad(harmony);
            new POptions().RegisterOptions(this, typeof(BCSmartBatteryOptions));
        }
    }
}
