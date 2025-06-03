using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector2 ToVector2(this Vector3 vector) => new Vector2(vector.X, vector.Y);
    }
}
