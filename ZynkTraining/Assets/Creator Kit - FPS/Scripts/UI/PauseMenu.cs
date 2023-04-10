using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }
    public GameObject settingsMenu;

    void Awake()
    { 
        Instance = this;
        gameObject.SetActive(false);//activate pause menu
        
    }

    public void Display()
    {
        gameObject.SetActive(true);//displays de menu
        GameSystem.Instance.StopTimer();//stops the time
        Controller.Instance.DisplayCursor(true);//displays the cursor
    }

    public void OpenEpisode()
    {
        if(LevelSelectionUI.Instance.IsEmpty())
            return;
        
        UIAudioPlayer.PlayPositive();
        gameObject.SetActive(false);
        LevelSelectionUI.Instance.DisplayEpisode();
    }

    public void ReturnToGame()
    {
        UIAudioPlayer.PlayPositive();//sound for buttons 
        GameSystem.Instance.StartTimer();//start the timer
        gameObject.SetActive(false);//deactivate pause menu
        Controller.Instance.DisplayCursor(false);//hides the cursor
    }

    public void Settings()
    {
        
        GameSystem.Instance.StopTimer();
        // deactivate PauseMenu
        gameObject.SetActive(false);

        // activate SettingsMenu
        settingsMenu.SetActive(true);
        
        

    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();//quit application
#endif
    }
}
