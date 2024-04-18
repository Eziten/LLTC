using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    float _moveSpeed;
    float _backMoveTime;

    Vector3 _targetPos;
    bool _isMove;

    private void OnEnable()
    {
        _isMove = false;
        _backMoveTime = 0.1f;
        _moveSpeed = 5.0f;
    }

    public void MoveStart(Vector3 _target)
    {        
        if (!_isMove)
        {
            _isMove = true;
            _targetPos = _target;
        }
    }

    private void Update()
    {
        if (!_isMove) return;

        Vector3 direction;

        if (_backMoveTime > 0)
        {
            _moveSpeed = 5.0f;

            _backMoveTime -= Time.deltaTime;

            direction = transform.position - _targetPos;

            transform.Translate(direction * _moveSpeed * Time.deltaTime);
        }
        else
        {
            _moveSpeed = 10.0f;
            _targetPos = Player.Instance.Transform.position;

            direction = _targetPos - transform.position;

            transform.Translate(direction * _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPos) <= 0.2f)
            {
                MoveEnd();
            }
        }
    }

    public virtual void MoveEnd()
    {

    }
}
