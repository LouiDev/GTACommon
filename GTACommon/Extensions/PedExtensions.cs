using GTA;
using GTA.Native;
using GTACommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class PedExtensions
    {
        /// <summary>
        /// Checks if the Ped is a male character.
        /// Returns false if female.
        /// </summary>
        public static bool IsMale(this Ped ped) => Function.Call<bool>(Hash.IS_PED_MALE, ped);

        public static void PlayAmbientSpeech(this Ped ped, CommonSpeeches speech, SpeechModifier modifier = SpeechModifier.Standard) => ped.PlayAmbientSpeech(speech.GetAsString(), modifier);
    }
}
