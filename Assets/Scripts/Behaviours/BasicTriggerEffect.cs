using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public abstract class BasicTriggerEffect : MonoBehaviour
    {
        [SerializeField]
        private string tagToFind;

        private void Awake()
        {
            if (tagToFind == null || tagToFind == "")
            {
                Debug.LogError("tag to find not specified!");
            }
        }

        protected abstract void TriggerEffect(Collider2D other);
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(tagToFind))
                TriggerEffect(other);
        }
    }
}