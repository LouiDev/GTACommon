using GTA;
using GTACommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class BlipExtensions
    {
        /// <summary>
        /// Sets the blip to flash for a specified time at a specified interval.
        /// </summary>
        public static void Flash(this Blip blip, int intervallMs, int timeMs)
        {
            blip.FlashInterval = intervallMs;
            blip.FlashTimeLeft = timeMs;
        }
    }
}
