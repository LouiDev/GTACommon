using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Checks if the entity is usable, meaning it exists, is alive, and not null.
        /// </summary>
        public static bool IsUsable(this Entity entity) => entity != null && entity.Exists() && entity.IsAlive;

        /// <summary>
        /// Checks if the entity is playing a specific animation.
        /// </summary>
        public static bool IsPlayingAnimation(this Entity entity, string animDict, string animName) => Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, entity, animDict, animName, 3);

        /// <summary>
        /// Checks if the entity has finished playing a specific animation.
        /// </summary>
        public static bool HasAnimationFinished(this Entity entity, string animDict, string animName) => Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, entity, animDict, animName, 3);
    
        public static float DistanceTo(this Entity entity, Entity otherEntity) => entity.Position.DistanceTo(otherEntity.Position);

        public static float DistanceTo(this Entity entity, Blip blip) => entity.Position.DistanceTo(blip.Position);

        public static float DistanceTo2D(this Entity entity, Entity otherEntity) => entity.Position.ToVector2().DistanceTo(otherEntity.Position.ToVector2());

        public static float DistanceTo2D(this Entity entity, Blip blip) => entity.Position.ToVector2().DistanceTo(blip.Position.ToVector2());
    }
}
