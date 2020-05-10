using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private RaceManager _manager;

    private void OnTriggerEnter(Collider other)
    {
        Racer otherRacer = other.gameObject.GetComponent<Racer>();
        if (!(otherRacer != null && otherRacer.GetCheckpoint() == this))
            return;

        _manager.SetNextCheckpoint(this, otherRacer);
    }
}
