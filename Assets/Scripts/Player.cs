using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SingleTon<Player>
{
    [SerializeField] Transform _transform;

    float _hp = 10f;
    float _speed = 2.0f;
    bool _isDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

        yield return new WaitForSeconds(0.2f);

        _isDamage = false;
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
