using GTA.Native;
using GTACommon.Enums;

namespace GTACommon.Extensions
{
    public static class ControllerButtonExtensions
    {
        public static string GetInstructionalId(this ControllerButton button) => Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, (int)button, true);
    }
}
