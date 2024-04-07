using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultMgr : Popup<ResultMgr>
{
    public void Show()
    {
        SetScreen();

        Open();
    }

    public void SetScreen()
    {

    }

    public void Click_Close()
    {
        Close();
    }

    public void Click_Restart()
    {
        Close();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
    }
}
