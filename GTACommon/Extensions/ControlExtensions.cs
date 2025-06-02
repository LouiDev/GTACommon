using GTA;
using GTA.Native;

namespace GTACommon.Extensions
{
    public static class ControlExtensions
    {
        public static string GetInstructionalId(this Control control) => Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, (int)control, true);
    }
}
