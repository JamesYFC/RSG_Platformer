using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RSGPlatformer.Game
{
    public interface IKillable
    {
        void Die(GameObject source);
    }
}