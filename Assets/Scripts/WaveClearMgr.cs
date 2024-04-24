using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Search;
using UnityEngine;

public class WaveClearMgr : Popup<WaveClearMgr>
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
        GameUIMgr.Instance.AddWaveCnt();
        Player.Instance.ResetPos();

        Close();

        GameUIMgr.Instance.SetGameState(GameState.WaveReady);
    }
}
