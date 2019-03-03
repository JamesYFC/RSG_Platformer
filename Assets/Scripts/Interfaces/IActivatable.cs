using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RSGPlatformer.Game
{
    public interface IActivatable
    {
        bool Activated { get; }
        void Activate();
        void Deactivate();
    }
}