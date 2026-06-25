using STRINGS;

namespace BCSmartBattery
{
    internal struct BuildingStrings
    {
        public readonly string Name;
        public readonly string Description;
        public readonly string Effect;

        public BuildingStrings(string name, string description, string effect)
        {
            Name = name;
            Description = description;
            Effect = effect;
        }
    }

    public class BUILDING_MOD
    {
        private static readonly BuildingStrings ChineseStrings = new BuildingStrings(
            "大容量智能电池",
            BUILDINGS.PREFABS.BATTERYSMART.DESC,
            BUILDINGS.PREFABS.BATTERYSMART.EFFECT);

        private static readonly BuildingStrings EnglishStrings = new BuildingStrings(
            "Large Smart Battery",
            BUILDINGS.PREFABS.BATTERYSMART.DESC,
            BUILDINGS.PREFABS.BATTERYSMART.EFFECT);

        internal static BuildingStrings GetLocalizedStrings()
        {
            string languageCode = Localization.GetCurrentLanguageCode();
            if (!string.IsNullOrEmpty(languageCode) && languageCode.StartsWith("zh"))
            {
                return ChineseStrings;
            }

            return EnglishStrings;
        }
    }
}
