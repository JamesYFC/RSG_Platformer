using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IKillable
{
    [SerializeField]
    private int killScore = 50;

    public virtual void Die(GameObject source)
    {
        GameController.Instance.AddScore(this, killScore);
    }

    
}
