using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField, Range(0, 1)]
    private float usedAlpha;

    [SerializeField]
    private int checkpointNum;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.CheckpointReached(checkpointNum);
            UpdateColour();
        }
    }

    private void UpdateColour()
    {
        Color newColor = sprite.color;
        newColor.a = usedAlpha;

        sprite.color = newColor;
    }
}
