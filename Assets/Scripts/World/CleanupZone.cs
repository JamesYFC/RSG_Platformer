using System.Collections.Generic;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class CleanupZone : MonoBehaviour
    {
        private HashSet<GameObject> searchedInvalids;
        private void Awake()
        {
            searchedInvalids = new HashSet<GameObject>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (searchedInvalids.Contains(other.gameObject))
                return;

            IActivatable foundActivatable = other.gameObject.GetComponentInChildren<IActivatable>();
            if (foundActivatable != null)
            {
                foundActivatable.Deactivate();
            }
            else
            {
                searchedInvalids.Add(other.gameObject);
            }
        }
    }
}