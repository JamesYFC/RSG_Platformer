using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IKillable
{
    [SerializeField]
    private int killScore;
    public virtual void Die()
    {
        GameController.Instance.AddScore(killScore);
    }
}
