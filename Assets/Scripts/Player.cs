using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SingleTon<Player>
{
    [SerializeField] Transform _transform;

    float _maxHp = 10f;
    float _hp = 10f;
    int _lv = 0;
    float _exp = 0;
    float _speed = 2.0f;
    bool _isDamage = false;

    float[] MaxExpArray = new float[10] { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550 };

    // Start is called before the first frame update
    void Start()
    {
        GameUIMgr.Instance.SetLvText($"Lv.{_lv}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Enemy" && !_isDamage)
        {
            StartCoroutine(Damage(collision.GetComponent<Enemy>().Power));
        }
    }

    IEnumerator Damage(float _power)
    {
        Handheld.Vibrate();

        _isDamage = true;

        _hp -= _power;

        if (_hp <= 0)
        {            
            Die();
        }

        GameUIMgr.Instance.HpBar.value = _hp / _maxHp;

        yield return new WaitForSeconds(0.2f);

        _isDamage = false;
    }

    public void AddExp(float _value)
    {
        if (_lv < MaxExpArray.Length)
        {
            _exp += _value;

            if (_exp >= MaxExpArray[_lv])
            {
                LevelUp();
            }

            GameUIMgr.Instance.ExpBar.value = _exp / MaxExpArray[_lv];
        }
    }

    void LevelUp()
    {
        _exp -= MaxExpArray[_lv];

        _lv++;

        GameUIMgr.Instance.SetLvText($"Lv.{_lv}");
    }

    void Die()
    {
        Debug.Log("Die");
    }

    public Transform Transform 
    {
        get { return _transform; } 
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

}
