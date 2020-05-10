using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _steeringAngle;

    [SerializeField]
    private float _maxSteeringAngle = 30f;
    [SerializeField]
    private float _acceleration = 50f;

    [SerializeField]
    private WheelCollider _frontRightCollider, _frontLeftCollider, _backRightCollider, _backLeftCollider;
    [SerializeField]
    private Transform _frontRightTransform, _frontLeftTransform, _backRightTransform, _backLeftTransform;

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    public float GetAccelerationInput ()
    {
        return _verticalInput;
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        _steeringAngle = _maxSteeringAngle * _horizontalInput;
        _frontLeftCollider.steerAngle = _steeringAngle;
        _frontRightCollider.steerAngle = _steeringAngle;
    }

    private void Accelerate()
    {
        _backLeftCollider.motorTorque = _acceleration * _verticalInput;
        _backRightCollider.motorTorque = _acceleration * _verticalInput;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(_frontRightCollider, _frontRightTransform);
        UpdateWheelPose(_frontLeftCollider, _frontLeftTransform);
        UpdateWheelPose(_backRightCollider, _backRightTransform);
        UpdateWheelPose(_backLeftCollider, _backLeftTransform);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 pos = _transform.position;
        Quaternion quat = _transform.rotation;

        _collider.GetWorldPose(out pos, out quat);

        _transform.SetPositionAndRotation(pos, quat);
    }
}
