using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationZone : MonoBehaviour, IResettable
{
    private List<IActivatable> objectsToActivate = new List<IActivatable>();
    [SerializeField]
    private string tagToFind;
 
    private void Awake()
    {
        if (objectsToActivate == null)
        {
            Debug.LogError("no objects to activate!");
        }

        if (tagToFind == null || tagToFind == "")
        {
            Debug.LogError("tag to find not specified!");
        }
    }

    private void Start()
    {
        DeactivateAll();
    }

    public void AddActivatable(IActivatable activatable)
    {
        objectsToActivate.Add(activatable);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger entered");
        if (other.gameObject.CompareTag(tagToFind))
        {
            Debug.Log("correct tag found");
            ActivateAll();
            gameObject.SetActive(false);
        }
    }

    private void ActivateAll()
    {
        foreach (IActivatable activatable in objectsToActivate)
        {
            activatable.Activate();
        }
    }
 
    public void ResetState()
    {
        DeactivateAll();
        gameObject.SetActive(true);
    }
  
    private void DeactivateAll()
    {
        foreach (IActivatable activatable in objectsToActivate)
        {
            activatable.Deactivate();
        }
    }
}
