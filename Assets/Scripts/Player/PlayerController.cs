using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IKillable, IResettable
{
    [SerializeField]
    private PlayerMovement playerMovement;

    public void Die()
    {
        Debug.Log("I am dead!");
        GameController.Instance.PlayerDied();
    }

    public void ResetState()
    {
        playerMovement.ResetState();
    }
}
