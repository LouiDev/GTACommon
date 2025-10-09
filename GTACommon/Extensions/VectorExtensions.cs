using GTA.Math;
using GTA;

namespace GTACommon.Extensions
{
    /// <summary>
    /// Provides extension methods for performing common operations on Vector2 and Vector3 instances, including distance
    /// calculations to entities and conversions between vector types.
    /// </summary>
    /// <remarks>These extension methods simplify vector-related calculations when working with entities and
    /// spatial data. All methods are static and can be called directly on Vector2 or Vector3 instances. Parameters
    /// representing entities must not be null.</remarks>
    public static class VectorExtensions
    {
        /// <summary>
        /// Calculates the distance between the specified vector and the position of the given entity.
        /// </summary>
        /// <param name="vector2">The source vector from which to measure the distance.</param>
        /// <param name="entity">The entity whose position is used as the target point for the distance calculation. Cannot be null.</param>
        /// <returns>The distance</returns>
        public static float DistanceTo(this Vector2 vector2, Entity entity) 
            => vector2.DistanceTo(entity.Position);

        /// <summary>
        /// Calculates the distance between the specified vector and the position of the given entity.
        /// </summary>
        /// <param name="vector3">The source vector from which to measure the distance.</param>
        /// <param name="entity">The entity whose position is used as the destination point. Cannot be null.</param>
        /// <returns>The distance</returns>
        public static float DistanceTo(this Vector3 vector3, Entity entity)
            => vector3.DistanceTo(entity.Position);

        /// <summary>
        /// Converts a Vector3 instance to a Vector2 by discarding the Z component.
        /// </summary>
        /// <param name="vector3">The Vector3 to convert. The X and Y components are preserved; the Z component is ignored.</param>
        /// <returns>A Vector2 containing the X and Y components of the specified Vector3.</returns>
        public static Vector2 ToVector2(this Vector3 vector3) 
            => new Vector2(vector3.X, vector3.Y);
    }
}
