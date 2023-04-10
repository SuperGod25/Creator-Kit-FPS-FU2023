using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private Toggle toggle;


    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            GameSystem.Instance.EnableSlowMotionEffect();
        }
        else
        {
            GameSystem.Instance.DisableSlowMotionEffect();
        }
    }

    public void Back()
    {
        UIAudioPlayer.PlayPositive();
        // dezactivează SettingsMenu
        gameObject.SetActive(false);

        // activează PauseMenu
        pauseMenu.SetActive(true);
    }
}
