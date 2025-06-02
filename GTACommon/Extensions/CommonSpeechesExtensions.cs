using GTA;
using GTACommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class CommonSpeechesExtensions
    {
        public static string GetAsString(this CommonSpeeches speech) => Enum.GetName(typeof(CommonSpeeches), speech) ?? string.Empty;

        public static void PlayForPed(this CommonSpeeches speech, Ped ped, SpeechModifier modifier) => ped.PlayAmbientSpeech(speech.GetAsString(), modifier);
    }
}
