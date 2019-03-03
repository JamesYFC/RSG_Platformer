using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTagOnTouch : MonoBehaviour
{
    [SerializeField]
    private string tagToKill;
    
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        GameObject collidedObject = collisionInfo.gameObject;
        if (collidedObject.tag != tagToKill) return;

        IKillable killable = collidedObject.GetComponent<IKillable>();
        if (killable != null)
        {
            killable.Die(gameObject);
        }
    }
}
