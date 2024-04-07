using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SingleTon<Player>
{
    [SerializeField] Transform _transform;
    [SerializeField] Transform[] WeaponSlot;
    float _maxHp = 10f;
    float _hp = 10f;
    int _lv = 0;
    float _exp = 0;
    float _speed = 2.0f;
    float _CheckItemRange = 0.5f;
    bool _isDamage = false;

    float[] MaxExpArray = new float[10] { 100, 150, 300, 600, 1000, 1500, 6400, 12800, 25600, 51200 };
    WeaponType[] WeaponTypeArray = new WeaponType[6] { WeaponType.None, WeaponType.None, WeaponType.None, WeaponType.None, WeaponType.None, WeaponType.None };

    // Start is called before the first frame update
    void Start()
    {
        GameUIMgr.Instance.SetLvText($"Lv.{_lv}");
    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Enemy" && !_isDamage)
        {
            StartCoroutine(Damage(collision.GetComponent<Enemy>().Power));
        }
    }

    void CheckItem()
    {
        Collider2D[] CheckItemArray = Physics2D.OverlapCircleAll(transform.position, _CheckItemRange);

        foreach (Collider2D target in CheckItemArray)
        {
            if (target.tag == "Item")
            {
                target.GetComponent<Item>().MoveToPlayer(transform.position);
            }
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

        if (_lv < WeaponTypeArray.Length)
        {
            WeaponMgr.Instance.Equip_Weapon("Weapon_Pistol", _lv);
        }
    }

    void Die()
    {
        Time.timeScale = 0;

        ResultMgr.Instance.Show();
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

    public void SetWeaponArray(int _IDX, WeaponType _value)
    {
        WeaponTypeArray[_IDX] = _value;
    }

    public WeaponType GetWeaponType(int _IDX)
    {
        return WeaponTypeArray[_IDX];
    }

    public Transform GetWeaponSlot(int _IDX)
    {
        return WeaponSlot[_IDX];
    }
}
