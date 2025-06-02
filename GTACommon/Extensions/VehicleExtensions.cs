using GTA;
using GTA.Native;
using GTACommon.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GTACommon.Extensions
{
    public static class VehicleExtensions
    {
        /// <summary>
        /// Gets the vehicle data from the vehicle instance, including all installed mods, colors, and other properties.
        /// </summary>
        public static VehicleData GetVehicleData(this Vehicle vehicle)
        {
            List<SerializableVehicleMod> mods = new List<SerializableVehicleMod>();
            foreach (int type in Enum.GetValues(typeof(VehicleModType)))
            {
                var mod = vehicle.Mods[(VehicleModType)type];
                if (mod.Index != -1)
                {
                    mods.Add(new SerializableVehicleMod
                    {
                        Variation = mod.Variation,
                        Index = mod.Index,
                        Type = (int)mod.Type
                    });
                }
            }

            List<int> toggleMods = new List<int>();
            foreach (int type in Enum.GetValues(typeof(VehicleToggleModType)))
            {
                var mod = vehicle.Mods[(VehicleToggleModType)type];
                if (mod.IsInstalled)
                    toggleMods.Add((int)mod.Type);
            }

            List<int> neonLights = new List<int>();
            foreach (var index in Enum.GetValues(typeof(VehicleNeonLight)))
            {
                if (vehicle.Mods.HasNeonLight((VehicleNeonLight)index))
                    neonLights.Add((int)index);
            }

            return new VehicleData
            {
                Model = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, vehicle.Model.Hash).ToLower(),
                CanTiresBurst = vehicle.CanTiresBurst,
                WheelType = (int)vehicle.Mods.WheelType,
                LicensePlateStyle = (int)vehicle.Mods.LicensePlateStyle,
                Livery = vehicle.Mods.Livery,
                InstalledMods = mods.ToArray(),
                InstalledToggleMods = toggleMods.ToArray(),
                InstalledNeonLights = neonLights.ToArray(),
                Colors = new VehicleColors
                {
                    ColorCombination = vehicle.Mods.ColorCombination,
                    ColorCombinationCount = vehicle.Mods.ColorCombinationCount,
                    PrimaryColor = (int)vehicle.Mods.PrimaryColor,
                    SecondaryColor = (int)vehicle.Mods.SecondaryColor,
                    PearlescentColor = (int)vehicle.Mods.PearlescentColor,
                    RimColor = (int)vehicle.Mods.RimColor,
                    DashboardColor = (int)vehicle.Mods.DashboardColor,
                    TrimColor = (int)vehicle.Mods.TrimColor,
                    CustomPrimaryColor = new SerializableColor(vehicle.Mods.CustomPrimaryColor),
                    CustomSecondaryColor = new SerializableColor(vehicle.Mods.CustomSecondaryColor),
                    NeonLightsColor = new SerializableColor(vehicle.Mods.NeonLightsColor),
                    TireSmokeColor = new SerializableColor(vehicle.Mods.TireSmokeColor)
                },
            };
        }

        /// <summary>
        /// Serializes the vehicle to JSON format.
        /// </summary>
        public static string ToJson(this Vehicle vehicle) => new JavaScriptSerializer().Serialize(vehicle.GetVehicleData());

        /// <summary>
        /// Checks if there is a free seat in the vehicle and returns it if available.
        /// </summary>
        public static bool GetNextFreeSeat(this Vehicle vehicle, out VehicleSeat seat)
        {
            seat = VehicleSeat.Any;

            if (vehicle == null || !vehicle.Exists() || !Function.Call<bool>(Hash.ARE_ANY_VEHICLE_SEATS_FREE, vehicle))
                return false;

            for (int i = 0; i < Function.Call<int>(Hash.GET_VEHICLE_MODEL_NUMBER_OF_SEATS, vehicle.Model.Hash); i++)
            {
                if (vehicle.IsSeatFree((VehicleSeat)i))
                {
                    seat = (VehicleSeat)i;
                    return true;
                }
            }
            return false;
        }
    }
}
