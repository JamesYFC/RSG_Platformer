using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IResettable
{
    private Vector3 initialPosition;
    [SerializeField]
    private string tagToFind;
    private void Awake()
    {
        if (tagToFind == null || tagToFind == "")
        {
            Debug.LogError("tag to find not specified!");
        }
    }
    protected abstract void PickupEffect(Collider2D other);
    private void OnTriggerEnter2D(Collider2D other)
    {
        PickupEffect(other);
        gameObject.SetActive(false);
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
    }
}
