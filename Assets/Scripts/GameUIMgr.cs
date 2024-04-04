using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMgr : SingleTon<GameUIMgr>
{
    [SerializeField] Slider _HpBar;
    [SerializeField] Slider _ExpBar;

    // Start is called before the first frame update
    void Start()
    {
        _ExpBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Slider HpBar
    {
        get { return _HpBar; }
    }
    public Slider ExpBar
    {
        get { return _ExpBar; }
    }
}
