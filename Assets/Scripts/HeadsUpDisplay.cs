using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeadsUpDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private Rigidbody _playerRB;
    private PlayerMovement _playerMovement;
    private Racer _playerRacer;

    [SerializeField]
    private Slider _gasSlider;
    [SerializeField]
    private Slider _brakeSlider;
    [SerializeField]
    private TextMeshProUGUI _speedTextBox;
    [SerializeField]
    private TextMeshProUGUI _timeTextBox;

    // Start is called before the first frame update
    void Start()
    {
        if (_player == null)
        {
            Debug.LogError("HUD has no reference to player");
            return;
        }
        _playerRB = _player.GetComponent<Rigidbody>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerRacer = _player.GetComponent<Racer>();
    }

    // Update is called once per frame
    void Update()
    {
        float acceleration = _playerMovement.GetAccelerationInput();
        _gasSlider.value = Mathf.Clamp(acceleration, _gasSlider.minValue, _gasSlider.maxValue);
        _brakeSlider.value = Mathf.Clamp(acceleration * -1f, _brakeSlider.minValue, _brakeSlider.maxValue);

        float speedInKilometersPerHour = _playerRB.velocity.magnitude * 3.6f;

        _speedTextBox.text = "Speed: " + speedInKilometersPerHour.ToString("n2") + " km/h";

        _timeTextBox.text = "Time: " + _playerRacer.GetElapsedTime().ToString("n2") + " seconds";
    }
}
