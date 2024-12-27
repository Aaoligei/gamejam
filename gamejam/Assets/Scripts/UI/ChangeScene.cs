using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool IsStop = false;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StopGame()
    {
        if(!IsStop)
        {
            Time.timeScale = 0;
            IsStop = true;
        }
        else
        {
            Time.timeScale = 1;
            IsStop = false;
        }
    }

    public void GOtoHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
