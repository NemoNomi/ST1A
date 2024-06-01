using UnityEngine;

#region Interface Definition
/// <summary>
/// Interface for movement controllers.
/// Provides a method to move an object to a specified target position.
/// </summary>
public interface IMovementController
{
    /// <summary>
    /// Moves the object to the specified target position.
    /// </summary>
    void MoveTo(Vector3 targetPosition);
}
#endregion
