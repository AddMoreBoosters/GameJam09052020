using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private Button _defaultSelectedButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu (Start)"))
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

        _defaultSelectedButton.Select();
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

    public void ReturnToMainMenu ()
    {
        DisableMenu();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        DisableMenu();
        Application.Quit();
    }
}
