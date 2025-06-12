using GTA;
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
        public static Vector2 ToVector2(this Vector3 vector3) => new Vector2(vector3.X, vector3.Y);

        public static float DistanceTo(this Vector3 vector3, Entity entity) => vector3.DistanceTo(entity.Position);
    }
}
