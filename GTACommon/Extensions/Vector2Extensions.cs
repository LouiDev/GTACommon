using GTA.Math;
using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class Vector2Extensions
    {
        public static float DistanceTo(this Vector2 vector2, Entity entity) => vector2.DistanceTo(entity.Position);
    }
}
