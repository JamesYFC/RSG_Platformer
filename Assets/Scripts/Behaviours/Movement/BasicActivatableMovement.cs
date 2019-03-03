using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicActivatableMovement : BasicMovement, IActivatable
{
    [SerializeField]
    private ActivationZone activationZone;

    public bool Activated {get; set;} = false;
 
    protected override void Awake()
    {
        base.Awake();
        activationZone.AddActivatable(this);
    }

    public virtual void Activate()
    {
        ResetState();
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);
        Activated = true;
    }

    public virtual void Deactivate()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
        Activated = false;
    }
}
