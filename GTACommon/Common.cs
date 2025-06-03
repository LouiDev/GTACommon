using GTA.Native;

namespace GTACommon
{
    public class Common
    {
        /// <summary>
        /// Starts a busy spinner with the specified text
        /// </summary>
        public static void StartSpinner(string text)
        {
            Function.Call(Hash.BEGIN_TEXT_COMMAND_BUSYSPINNER_ON, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
            Function.Call(Hash.END_TEXT_COMMAND_BUSYSPINNER_ON, 3);
        }

        /// <summary>
        /// Ends the current busy spinner
        /// </summary>
        public static void EndSpinner() => Function.Call(Hash.BUSYSPINNER_OFF);
    }
}
