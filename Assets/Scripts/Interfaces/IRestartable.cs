using UnityEngine;

namespace RSGPlatformer.Game
{
    /// <summary>
    /// An interface for objects that should be restored to their original state e.g. in case of a checkpoint restart.
    /// </summary>
    public interface IResettable
    {
        void ResetState();
    }
}