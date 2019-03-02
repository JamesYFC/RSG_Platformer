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
        Debug.Log("collided with " + collidedObject);

        if (collidedObject.tag != tagToKill)
        {
            Debug.Log("wrong tag");
            return;
        }

        IKillable killable = collidedObject.GetComponent<IKillable>();

        if (killable != null)
        {
            killable.Die();
        }
    }
}
