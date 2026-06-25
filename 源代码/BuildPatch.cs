using HarmonyLib;

namespace BCSmartBattery
{
    public static class BuildPatch
    {
        private const string PowerPlanScreen = "Power";
        private const string RenewableEnergyTechId = "RenewableEnergy";

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class BCSmartBattery_LoadGeneratedBuildings_Patch
        {
            [HarmonyPrefix]
            public static void Prefix()
            {
                var batterySubcategory = TUNING.BUILDINGS.PlanSubcategoryName.batteries.ToString();

                ModUtil.AddBuildingToPlanScreen(
                    PowerPlanScreen,
                    BCSmartBatteryConfig.ID,
                    batterySubcategory,
                    BatterySmartConfig.ID);

                if (TUNING.BUILDINGS.PLANSUBCATEGORYSORTING != null)
                {
                    TUNING.BUILDINGS.PLANSUBCATEGORYSORTING[BCSmartBatteryConfig.ID] = batterySubcategory;
                }

                BuildingStrings strings = BUILDING_MOD.GetLocalizedStrings();
                StringUtils.Add_New_BuildStrings(
                    BCSmartBatteryConfig.ID,
                    strings.Name,
                    strings.Description,
                    strings.Effect);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public static class BCSmartBattery_Db_Initialize_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                var db = Db.Get();
                if (db == null)
                {
                    return;
                }

                if (db.Techs == null)
                {
                    return;
                }

                var renewableEnergyTech = db.Techs.Get(RenewableEnergyTechId);
                if (renewableEnergyTech == null || renewableEnergyTech.unlockedItemIDs == null)
                {
                    return;
                }

                if (!renewableEnergyTech.unlockedItemIDs.Contains(BCSmartBatteryConfig.ID))
                {
                    renewableEnergyTech.unlockedItemIDs.Add(BCSmartBatteryConfig.ID);
                }
            }
        }
    }
}
