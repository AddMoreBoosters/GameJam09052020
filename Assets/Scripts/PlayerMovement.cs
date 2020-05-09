using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _rotationSpeed = 1f;
    [SerializeField]
    private Transform _camera;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("No Rigidbody found, creating a new one");
            _rb = new Rigidbody();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rb.transform.Rotate(new Vector3(0f, 1f, 0f), Input.GetAxis("Mouse X") * _rotationSpeed);
        _camera.transform.Rotate(new Vector3(1f, 0f, 0f), Input.GetAxis("Mouse Y") * _rotationSpeed);

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _rb.transform.Translate(movementVector * _speed * Time.deltaTime, Space.Self);
    }
}
