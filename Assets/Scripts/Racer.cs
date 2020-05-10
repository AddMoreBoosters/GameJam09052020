using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    [SerializeField]
    private Checkpoint _nextCheckpoint;
    [SerializeField]
    private float _elapsedTime;
    [SerializeField]
    private bool _timerRunning = true;

    private void Start()
    {
        _elapsedTime = 0f;
    }

    private void Update()
    {
        if (_timerRunning == true)
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    public Checkpoint GetCheckpoint()
    {
        return _nextCheckpoint;
    }

    public void SetCheckpoint(Checkpoint newCheckpoint)
    {
        _nextCheckpoint = newCheckpoint;
    }

    public void SetTimerRunning (bool running)
    {
        _timerRunning = running;
    }

    public float GetElapsedTime ()
    {
        return _elapsedTime;
    }
}
