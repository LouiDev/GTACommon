using GTA;
using GTA.Native;
using GTACommon.Serialization;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace GTACommon.Extensions
{
    /// <summary>
    /// Provides extension methods for retrieving data, serializing, and seat management operations on Vehicle
    /// instances.
    /// </summary>
    public static class VehicleExtensions
    {
        /// <summary>
        /// Retrieves comprehensive data describing the current state and modifications of the specified vehicle.
        /// </summary>
        /// <remarks>The returned VehicleData reflects the vehicle's current configuration, including all
        /// installed mods and color settings. This method does not modify the vehicle and can be called repeatedly to
        /// obtain up-to-date information.</remarks>
        /// <param name="vehicle">The vehicle instance from which to extract modification and appearance data. Cannot be null.</param>
        /// <returns>A VehicleData object containing details about the vehicle's model, installed modifications, neon lights,
        /// colors, and other relevant attributes.</returns>
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
        /// Serializes the specified vehicle to a JSON string representation.
        /// </summary>
        /// <param name="vehicle">The vehicle instance to serialize. Cannot be null.</param>
        /// <returns>A JSON-formatted string that represents the vehicle's data.</returns>
        public static string ToJson(this Vehicle vehicle)
            => new JavaScriptSerializer().Serialize(vehicle.GetVehicleData());

        /// <summary>
        /// Attempts to find the next available seat in the specified vehicle.
        /// </summary>
        /// <remarks>This method checks all seats in the vehicle and returns the first available one. If
        /// no seats are free or the vehicle is invalid, <paramref name="seat"/> is set to <see cref="VehicleSeat.Any"/>
        /// and the method returns false.</remarks>
        /// <param name="vehicle">The vehicle in which to search for a free seat. Must not be null and must exist in the game world.</param>
        /// <param name="seat">When this method returns, contains the first free seat found in the vehicle, or <see
        /// cref="VehicleSeat.Any"/> if no seat is available.</param>
        /// <returns>true if a free seat is found; otherwise, false.</returns>
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
