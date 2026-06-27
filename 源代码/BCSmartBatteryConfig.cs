using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace BCSmartBattery
{
    public class BCSmartBatteryConfig : BaseBatteryConfig
    {
        public const string ID = "BCSmartBattery";
        private const string Anim = "smartbattery_kanim";
        private const int Width = 2;
        private const int Height = 2;
        private const int Hitpoints = 30;
        private const float ConstructionTime = 60f;
        private const float MeltingPoint = 800f;
        private const float ExhaustTemperatureActive = 0f;
        private const float CapacityJoules = 100000f;
        private const int PowerSortOrder = 1000;
        private static readonly Color32 SteelTint = new Color32(125, 175, 195, 255);

        public override BuildingDef CreateBuildingDef()
        {
            BCSmartBatteryBalanceProfile balance = BCSmartBatteryOptions.CurrentProfile;

            // Construction materials and mass.
            float[] construction_mass = new float[]
            {
                balance.SteelMassKg,
                balance.PlasticMassKg,
                balance.GlassMassKg
            };
            string[] construction_materials = new string[]
            {
                SimHashes.Steel.ToString(),
                MATERIALS.PLASTIC,
                MATERIALS.GLASS
            };

            EffectorValues noise = NOISE_POLLUTION.NOISY.TIER1;

            BuildingDef buildingDef = base.CreateBuildingDef(
                ID, Width, Height, Hitpoints, Anim,
                ConstructionTime, construction_mass, construction_materials,
                MeltingPoint, ExhaustTemperatureActive,
                balance.SelfHeatKilowatts,
                TUNING.BUILDINGS.DECOR.PENALTY.TIER2,
                noise
            );

            // Logic output port.
            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>
            {
                LogicPorts.Port.OutputPort(
                    BatterySmart.PORT_ID,
                    new CellOffset(0, 0),
                    STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT,
                    STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_ACTIVE,
                    STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_INACTIVE,
                    true, false)
            };

            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            BCSmartBatteryBalanceProfile balance = BCSmartBatteryOptions.CurrentProfile;
            BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
            batterySmart.capacity = CapacityJoules;
            batterySmart.joulesLostPerSecond = balance.JoulesLostPerSecond;
            batterySmart.powerSortOrder = PowerSortOrder;
            base.DoPostConfigureComplete(go);

            BCSmartBatterySteelTint.ApplyTint(go, SteelTint);
            go.AddOrGet<BCSmartBatterySteelTint>();
        }
    }

    internal sealed class BCSmartBatterySteelTint : MonoBehaviour
    {
        private static readonly Color32 RuntimeTint = new Color32(125, 175, 195, 255);

        internal static void ApplyTint(GameObject go, Color32 tint)
        {
            KBatchedAnimController animController = go.GetComponent<KBatchedAnimController>();
            if (animController == null)
            {
                return;
            }

            animController.TintColour = tint;
            animController.SetDirty();
        }

        private void OnEnable()
        {
            ApplyTint(gameObject, RuntimeTint);
        }

        private void Start()
        {
            ApplyTint(gameObject, RuntimeTint);
        }
    }
}
