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
    /// </summary>
    [SerializeField] TextMeshProUGUI[] _Text;
    /// <summary>
    /// 0 : 고정형
    /// 1 : 플로팅형
    /// </summary>
    [SerializeField] Joystick[] _Joysticks;
    // Start is called before the first frame update
    void Start()
    {
        _ExpBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
}
