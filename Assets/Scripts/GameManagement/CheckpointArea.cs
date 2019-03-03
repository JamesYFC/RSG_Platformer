using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CheckpointArea
{
    [SerializeField]
    private List<ActivationZone> checkpointZones;
    [SerializeField]
    private Transform _spawnPoint;
    public Transform SpawnPoint => _spawnPoint;
    public void ResetZones()
    {
        foreach (var activationZone in checkpointZones)
        {
            activationZone.ResetState();
        }
    }

    
}