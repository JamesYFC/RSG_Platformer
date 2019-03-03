using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class Checkpoint : BasicTriggerEffect
    {
        [SerializeField]
        private SpriteRenderer sprite;
        [SerializeField, Range(0, 1)]
        private float usedAlpha;

        private int checkpointNum;
        [SerializeField]
        private int scoreBonus = 100;

        private bool used = false;

        public void Setup(int checkpointNum)
        {
            this.checkpointNum = checkpointNum;
        }

        public void Use()
        {
            used = true;
            GameController.Instance.CheckpointReached(checkpointNum);
            if (checkpointNum > 0)
                GameController.Instance.AddScore(this, scoreBonus * GameController.Instance.CurrentLives);
            UpdateColour();
        }

        protected override void TriggerEffect(Collider2D other)
        {
            if (!used)
                Use();
        }

        private void UpdateColour()
        {
            Color newColor = sprite.color;
            newColor.a = usedAlpha;

            sprite.color = newColor;
        }
    }
}
