using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingleTon<Player>
{
    [SerializeField] Transform _transform;

    float _speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Get

    public Transform GetTransform()
    {
        return _transform;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    #endregion

}
