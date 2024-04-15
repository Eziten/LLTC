using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    float _moveSpeed = 10.0f;
    float _backMoveTime = 0.2f;

    Vector3 _targetPos;
    bool _targetPosCheck = false;
    bool _isMove = false;

    private void OnEnable()
    {
        _isMove = false;
        _backMoveTime = 0.2f;
        _moveSpeed = 3.0f;
    }

    public void MoveStart(Vector3 _target)
    {
        _isMove = true;

        if (!_targetPosCheck)
        {
            _targetPosCheck = true;
            _targetPos = _target;
        }
    }

    private void Update()
    {
        if (!_isMove) return;

        Vector3 direction;

        if (_backMoveTime > 0)
        {
            _moveSpeed = 3.0f;

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
