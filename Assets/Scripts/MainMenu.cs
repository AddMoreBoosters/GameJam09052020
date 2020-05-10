using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _defaultSelectedButton;

    private void Start()
    {
        _defaultSelectedButton.Select();
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("TimeTrial");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
