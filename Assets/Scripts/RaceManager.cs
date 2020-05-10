using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField]
    private List<Checkpoint> _checkpoints;

    public void SetNextCheckpoint (Checkpoint currentCheckpoint, Racer racer)
    {
        int currentIndex = _checkpoints.IndexOf(currentCheckpoint);
        if ((currentIndex + 1) == _checkpoints.Count)
        {
            racer.SetTimerRunning(false);
            Debug.Log("Finished! Time was " + racer.GetElapsedTime() + " seconds");
        }
        else if (_checkpoints[currentIndex + 1] != null)
        {
            racer.SetCheckpoint(_checkpoints[currentIndex + 1]);
        }
    }

    public int GetIndexOfCheckpoint(Checkpoint checkpoint)
    {
        return _checkpoints.IndexOf(checkpoint);
    }
}
