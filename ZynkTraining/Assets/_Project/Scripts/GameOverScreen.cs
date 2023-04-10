using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    private void Start()
    {
        Controller.Instance.DisplayCursor(true);//activate the cursor
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);//load the main scene
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();//quit application
#endif
    }

}
