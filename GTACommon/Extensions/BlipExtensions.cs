using GTA;

namespace GTACommon.Extensions
{
    /// <summary>
    /// Provides extension methods for the Blip type to enhance its functionality.
    /// </summary>
    /// <remarks>This static class contains methods that extend the capabilities of Blip instances, allowing
    /// for additional behaviors such as flashing. All methods are implemented as extension methods and can be called
    /// directly on Blip objects.</remarks>
    public static class BlipExtensions
    {
        /// <summary>
        /// Starts flashing the specified blip at the given interval for a specified duration.
        /// </summary>
        /// <param name="blip">The blip to be flashed. Cannot be null.</param>
        /// <param name="intervallMs">The interval, in milliseconds, between each flash. Must be greater than zero.</param>
        /// <param name="timeMs">The total duration, in milliseconds, for which the blip will flash. Must be greater than zero.</param>
        public static void Flash(this Blip blip, int intervallMs, int timeMs)
        {
            blip.FlashInterval = intervallMs;
            blip.FlashTimeLeft = timeMs;
        }
    }
}
