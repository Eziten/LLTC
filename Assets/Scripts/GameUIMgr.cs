using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMgr : SingleTon<GameUIMgr>
{
    [SerializeField] Slider _HpBar;
    [SerializeField] Slider _ExpBar;
    /// <summary>
    /// 0 : 현재 레벨
    /// 1 : 현재 웨이브 진행도
    /// 2 : 현재 웨이브 남은 시간
    /// </summary>
    [SerializeField] TextMeshProUGUI[] _Text;
    /// <summary>
    /// 0 : 고정형
    /// 1 : 플로팅형
    /// </summary>
    [SerializeField] Joystick[] _Joysticks;

    GameState _GameState = GameState.WaveReady;
    int _WaveCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        _ExpBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameState(GameState state)
    {
        _GameState = state;

        switch (_GameState)
        {
            case GameState.WaveReady:
                StartCoroutine(WaveReady());
                break;
            case GameState.WaveStart:
                WaveStart();
                break;
            case GameState.WaveEnd:
                WaveEnd();
                break;
            case GameState.Result:
                StopAllCoroutines();

                ResultMgr.Instance.Show();
                break;
        }
    }

    IEnumerator WaveReady()
    {
        _Text[1].text = $"Wave {_WaveCnt + 1}";

        yield return new WaitForSeconds(1.0f);

        ToastMgr.Instance.Show($"Wave {_WaveCnt + 1}");

        SetGameState(GameState.WaveStart);
    }

    void WaveStart()
    {
        StartCoroutine(StageMgr.Instance.SpawnEnemy());
        StartCoroutine(WaveTimer(30));
    }

    void WaveEnd()
    {
        WaveClearMgr.Instance.Show();
    }

    public bool CheckInGame()
    {
        return _GameState == GameState.WaveStart;
    }

    IEnumerator WaveTimer(int _time)
    {
        for (int i = _time; i > 0; i--)
        {
            yield return new WaitForSeconds(1.0f);

            _Text[2].text = string.Format("00:{0:D2}", i);
        }

        SetGameState(GameState.WaveEnd);
    }

    public GameState GetGameState()
    {
        return _GameState;
    }

    public Joystick FixedJoystick
    {
        get { return _Joysticks[0]; }
    }

    public Joystick FloatingJoystick
    {
        get { return _Joysticks[1]; }
    }

    public Slider HpBar
    {
        get { return _HpBar; }
    }
    public Slider ExpBar
    {
        get { return _ExpBar; }
    }
    
    public void SetLvText(string _value)
    {
        _Text[0].text = _value;
    }

    public void AddWaveCnt()
    {
        _WaveCnt++;
    }
}
