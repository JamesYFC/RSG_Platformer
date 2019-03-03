using UnityEngine;

/// <summary>
/// An interface for objects that should be restored to their original state in case of a checkpoint restart.
/// </summary>
public interface IResettable
{
    void ResetState();
}
