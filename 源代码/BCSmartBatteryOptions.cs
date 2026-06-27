using PeterHan.PLib.Options;

namespace BCSmartBattery
{
    internal enum BCSmartBatteryCostMode
    {
        [Option("轻量成本 / Light Cost", "800kg钢、100kg塑料、100kg玻璃、6.7J/s漏电、5kDTU/s发热 / 800 kg steel, 100 kg plastic, 100 kg glass, 6.7 J/s power loss, 5 kDTU/s heat.", null)]
        LightCost = 0,

        [Option("标准成本 / Standard Cost", "1200kg钢、150kg塑料、150kg玻璃、10J/s漏电、7.5kDTU/s发热 / 1200 kg steel, 150 kg plastic, 150 kg glass, 10 J/s power loss, 7.5 kDTU/s heat.", null)]
        StandardCost = 1
    }

    internal sealed class BCSmartBatteryBalanceProfile
    {
        internal readonly float SteelMassKg;
        internal readonly float PlasticMassKg;
        internal readonly float GlassMassKg;
        internal readonly float JoulesLostPerSecond;
        internal readonly float SelfHeatKilowatts;

        internal BCSmartBatteryBalanceProfile(
            float steelMassKg,
            float plasticMassKg,
            float glassMassKg,
            float joulesLostPerSecond,
            float selfHeatKilowatts)
        {
            SteelMassKg = steelMassKg;
            PlasticMassKg = plasticMassKg;
            GlassMassKg = glassMassKg;
            JoulesLostPerSecond = joulesLostPerSecond;
            SelfHeatKilowatts = selfHeatKilowatts;
        }
    }

    [ConfigFile("BCSmartBatteryOptions.json", true, false)]
    [RestartRequired]
    internal sealed class BCSmartBatteryOptions : SingletonOptions<BCSmartBatteryOptions>
    {
        private static readonly BCSmartBatteryBalanceProfile LightCostProfile =
            new BCSmartBatteryBalanceProfile(800f, 100f, 100f, 6.7f, 5f);
        private static readonly BCSmartBatteryBalanceProfile StandardCostProfile =
            new BCSmartBatteryBalanceProfile(1200f, 150f, 150f, 10f, 7.5f);

        [Option("成本模式 / Cost Preset", "默认使用“标准成本”。如需较低建造和运行代价，可以切换到“轻量成本”。修改后需要重启游戏，使建筑配方、漏电和发热参数完全刷新。 / Standard Cost is the default. Choose Light Cost for lower construction and operating costs. Restart the game after changing this option so recipe, power loss, and heat values refresh completely.", null)]
        public BCSmartBatteryCostMode CostMode { get; set; }

        public BCSmartBatteryOptions()
        {
            CostMode = BCSmartBatteryCostMode.StandardCost;
        }

        internal static BCSmartBatteryBalanceProfile CurrentProfile
        {
            get
            {
                if (Instance != null && Instance.CostMode == BCSmartBatteryCostMode.StandardCost)
                {
                    return StandardCostProfile;
                }

                return LightCostProfile;
            }
        }
    }
}
