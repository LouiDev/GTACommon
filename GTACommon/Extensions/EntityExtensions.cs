using GTA;
using GTA.Math;
using GTA.Native;
using GTACommon.Enums;

namespace GTACommon.Extensions
{
    /// <summary>
    /// Provides extension methods for entity-related types to simplify common operations such as distance calculations,
    /// animation checks, and speech playback.
    /// </summary>
    /// <remarks>This static class includes utility methods for working with entities, pedestrians, players,
    /// and blips in the game environment. The extensions are designed to improve code readability and reduce
    /// boilerplate when performing frequent tasks, such as determining entity usability, checking animations, or
    /// triggering ambient speech. All methods are intended for use with valid, non-null objects and may throw
    /// exceptions if called with invalid arguments.</remarks>
    public static class EntityExtensions
    {
        /// <summary>
        /// Determines whether the specified entity is usable by checking that it is not null, exists, and is alive.
        /// </summary>
        /// <param name="entity">The entity to evaluate for usability. Must not be null.</param>
        /// <returns>true if the entity is not null, exists, and is alive; otherwise, false.</returns>
        public static bool IsUsable(this Entity entity) 
            => entity != null && entity.Exists() && entity.IsAlive;

        /// <summary>
        /// Determines whether the specified entity is currently playing the given animation.
        /// </summary>
        /// <param name="entity">The entity to check for the active animation. Cannot be null.</param>
        /// <param name="animDict">The name of the animation dictionary containing the animation. Must not be null or empty.</param>
        /// <param name="animName">The name of the animation to check. Must not be null or empty.</param>
        /// <returns>true if the entity is playing the specified animation; otherwise, false.</returns>
        public static bool IsPlayingAnimation(this Entity entity, string animDict, string animName) 
            => Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, entity, animDict, animName, 3);

        /// <summary>
        /// Determines whether the specified entity has finished playing the given animation.
        /// </summary>
        /// <param name="entity">The entity to check for the completion of the animation.</param>
        /// <param name="animDict">The name of the animation dictionary containing the animation. Cannot be null or empty.</param>
        /// <param name="animName">The name of the animation to check. Cannot be null or empty.</param>
        /// <returns>true if the entity has finished playing the specified animation; otherwise, false.</returns>
        public static bool HasAnimationFinished(this Entity entity, string animDict, string animName) 
            => Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, entity, animDict, animName, 3);
    
        /// <summary>
        /// Calculates the distance between the positions of two entities.
        /// </summary>
        /// <param name="entity">The entity from which the distance is measured.</param>
        /// <param name="otherEntity">The entity to which the distance is measured.</param>
        /// <returns>The distance between the positions of <paramref name="entity"/> and <paramref
        /// name="otherEntity"/>.</returns>
        public static float DistanceTo(this Entity entity, Entity otherEntity) 
            => entity.Position.DistanceTo(otherEntity.Position);

        /// <summary>
        /// Calculates the distance between the specified entity and blip positions.
        /// </summary>
        /// <param name="entity">The entity whose position is used as the starting point for the distance calculation. Cannot be null.</param>
        /// <param name="blip">The blip whose position is used as the end point for the distance calculation. Cannot be null.</param>
        /// <returns>The distance between the entity and the blip positions</returns>
        public static float DistanceTo(this Entity entity, Blip blip) 
            => entity.Position.DistanceTo(blip.Position);

        /// <summary>
        /// Calculates the distance between the specified entity's position and a Vector3 position.
        /// </summary>
        /// <param name="entity">The entity whose position is used as the starting point for the distance calculation. Cannot be null.</param>
        /// <param name="vector3">The target point in three-dimensional space to which the distance is measured.</param>
        /// <returns>the distance between the entity's position and the Vector3 position</returns>
        public static float DistanceTo(this Entity entity, Vector3 vector3) 
            => entity.Position.DistanceTo(vector3);

        /// <summary>
        /// Calculates the two-dimensional distance between the positions of the specified entities.
        /// </summary>
        /// <param name="entity">The entity from which the distance is measured.</param>
        /// <param name="otherEntity">The entity to which the distance is measured.</param>
        /// <returns>the distance between the two entities in 2D space.</returns>
        public static float DistanceTo2D(this Entity entity, Entity otherEntity) 
            => entity.Position.ToVector2().DistanceTo(otherEntity.Position.ToVector2());

        /// <summary>
        /// Calculates the two-dimensional distance between the specified entity and blip.
        /// </summary>
        /// <param name="entity">The entity whose position is used as the starting point for the distance calculation. Cannot be null.</param>
        /// <param name="blip">The blip whose position is used as the end point for the distance calculation. Cannot be null.</param>
        /// <returns>The distance between the entity and the blip in 2D space.</returns>
        public static float DistanceTo2D(this Entity entity, Blip blip) 
            => entity.Position.ToVector2().DistanceTo(blip.Position.ToVector2());

        /// <summary>
        /// Calculates the two-dimensional distance between the entity's position and the specified Vector2.
        /// </summary>
        /// <param name="entity">The entity whose position is used as the starting point for the distance calculation. Cannot be null.</param>
        /// <param name="vector2">The target position as a two-dimensional vector to which the distance is measured.</param>
        /// <returns>The distance between the entity's position and the specified Vector in 2D space.</returns>
        public static float DistanceTo2D(this Entity entity, Vector2 vector2) 
            => entity.Position.ToVector2().DistanceTo(vector2);

        /// <summary>
        /// Checks if the Ped is a male character.
        /// </summary>
        /// <returns>Returns false if female</returns>
        public static bool IsMale(this Ped ped)
            => Function.Call<bool>(Hash.IS_PED_MALE, ped);

        /// <summary>
        /// Plays an ambient speech line for the specified pedestrian using the given speech type and modifier.
        /// </summary>
        /// <remarks>This method is an extension for the <c>Ped</c> type and provides a convenient way to
        /// trigger predefined ambient speech lines. The actual speech played depends on the game context and the
        /// specified modifier.</remarks>
        /// <param name="ped">The pedestrian for whom the ambient speech will be played. Cannot be null.</param>
        /// <param name="speech">The type of speech to play. Specifies which ambient line will be spoken.</param>
        /// <param name="modifier">The modifier that affects how the speech is played, such as urgency or emotion. Defaults to <see
        /// cref="SpeechModifier.Standard"/>.</param>
        public static void PlayAmbientSpeech(this Ped ped, CommonSpeeches speech, SpeechModifier modifier = SpeechModifier.Standard)
            => ped.PlayAmbientSpeech(speech.GetAsString(), modifier);

        /// <summary>
        /// Determines whether the specified player is using a custom character model instead of one of the default
        /// protagonist models.
        /// </summary>
        /// <remarks>This method considers a model custom if it is human and not assigned to Franklin,
        /// Michael, or Trevor. Non-human models always return false.</remarks>
        /// <param name="player">The player whose character model is evaluated. Cannot be null.</param>
        /// <returns>true if the player's character model is human and not one of the default protagonist models; otherwise,
        /// false.</returns>
        public static bool IsUsingCustomModel(this Player player)
        {
            if (!player.Character.Model.IsHumanPed)
                return false;

            var _pedHash = (PedHash)player.Character.Model.Hash;
            return _pedHash != PedHash.Franklin &&
                _pedHash != PedHash.Franklin02 &&
                _pedHash != PedHash.Michael &&
                _pedHash != PedHash.Trevor;
        }
    }
}
