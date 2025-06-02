using GTA.Math;
using GTA;
using System.Web.Script.Serialization;

namespace GTACommon.Serialization
{
    public class VehicleData
    {
        public string Model { get; set; }
        public int WheelType { get; set; }
        public int LicensePlateStyle { get; set; }
        public int Livery { get; set; }
        public bool CanTiresBurst { get; set; }
        public SerializableVehicleMod[] InstalledMods { get; set; }
        public int[] InstalledToggleMods { get; set; }
        public int[] InstalledNeonLights { get; set; }
        public VehicleColors Colors { get; set; }

        /// <summary>
        /// Creates a vehicle at the specified position with the specified heading from this vehicle data.
        /// </summary>
        public Vehicle CreateVehicle(Vector3 spawnPos, float heading = 0f)
        {
            Vehicle vehicle = World.CreateVehicle(new Model(Model), spawnPos, heading);
            vehicle.CanTiresBurst = CanTiresBurst;
            vehicle.Mods.InstallModKit();
            vehicle.Mods.WheelType = (VehicleWheelType)WheelType;
            vehicle.Mods.LicensePlateStyle = (LicensePlateStyle)LicensePlateStyle;
            vehicle.Mods.Livery = Livery;
            vehicle.Mods.PrimaryColor = (VehicleColor)Colors.PrimaryColor;
            vehicle.Mods.SecondaryColor = (VehicleColor)Colors.SecondaryColor;
            vehicle.Mods.PearlescentColor = (VehicleColor)Colors.PearlescentColor;
            vehicle.Mods.RimColor = (VehicleColor)Colors.RimColor;
            vehicle.Mods.DashboardColor = (VehicleColor)Colors.DashboardColor;
            vehicle.Mods.TrimColor = (VehicleColor)Colors.TrimColor;
            vehicle.Mods.CustomPrimaryColor = Colors.CustomPrimaryColor.ToColor();
            vehicle.Mods.CustomSecondaryColor = Colors.CustomSecondaryColor.ToColor();
            vehicle.Mods.NeonLightsColor = Colors.NeonLightsColor.ToColor();
            vehicle.Mods.TireSmokeColor = Colors.TireSmokeColor.ToColor();

            foreach (var mod in InstalledMods)
            {
                vehicle.Mods[(VehicleModType)mod.Type].Index = mod.Index;
                vehicle.Mods[(VehicleModType)mod.Type].Variation = mod.Variation;
            }

            foreach (var index in InstalledToggleMods)
                vehicle.Mods[(VehicleToggleModType)index].IsInstalled = true;

            foreach (var index in InstalledNeonLights)
                vehicle.Mods.SetNeonLightsOn((VehicleNeonLight)index, true);

            return vehicle;
        }

        public string ToJson() => new JavaScriptSerializer().Serialize(this);

        /// <summary>
        /// Deserializes the JSON string to a VehicleData object.
        /// </summary>
        /// <param name="json"></param>
        public static VehicleData FromJson(string json) => new JavaScriptSerializer().Deserialize<VehicleData>(json);
    }
}
