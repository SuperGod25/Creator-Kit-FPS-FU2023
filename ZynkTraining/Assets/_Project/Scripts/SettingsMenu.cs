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
            GameSystem.Instance.EnableSlowMotionEffect();//enable slow-mo
        }
        else
        {
            GameSystem.Instance.DisableSlowMotionEffect();//disable slo-mo
        }
    }

    public void Back()
    {
        UIAudioPlayer.PlayPositive();
        // deactivate SettingsMenu
        gameObject.SetActive(false);

        // activate PauseMenu
        pauseMenu.SetActive(true);
    }
}
