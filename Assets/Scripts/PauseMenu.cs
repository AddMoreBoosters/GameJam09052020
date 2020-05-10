using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (_menu.activeInHierarchy == true)
            {
                DisableMenu();
            }
            else
            {
                EnableMenu();
            }
        }
    }

    private void EnableMenu ()
    {
        _menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableMenu ()
    {
        _menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame ()
    {
        DisableMenu();
        SceneManager.LoadScene("TimeTrial");
    }

    public void QuitGame ()
    {
        DisableMenu();
        Application.Quit();
    }
}
