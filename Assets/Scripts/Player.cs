using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingleTon<Player>
{
    [SerializeField] Rigidbody2D _rigidbody;

    float _speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Get

    public Rigidbody2D GetRigidbody()
    {
        return _rigidbody;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    #endregion

}
