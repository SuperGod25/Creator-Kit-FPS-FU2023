using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    public void Back()
    {
        UIAudioPlayer.PlayPositive();
        // dezactivează SettingsMenu
        gameObject.SetActive(false);

        // activează PauseMenu
        pauseMenu.SetActive(true);
    }
}
