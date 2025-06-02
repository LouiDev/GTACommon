namespace GTACommon.Serialization
{
    public class VehicleColors
    {
        public int ColorCombination { get; set; }
        public int ColorCombinationCount { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public int PearlescentColor { get; set; }
        public int RimColor { get; set; }
        public int DashboardColor { get; set; }
        public int TrimColor { get; set; }
        public SerializableColor CustomPrimaryColor { get; set; }
        public SerializableColor CustomSecondaryColor { get; set; }
        public SerializableColor NeonLightsColor { get; set; }
        public SerializableColor TireSmokeColor { get; set; }
    }
}
