using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    [SerializeField]
    private int scoreGained;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.AddScore(this, scoreGained);
            gameObject.SetActive(false);
        }
    }
}
