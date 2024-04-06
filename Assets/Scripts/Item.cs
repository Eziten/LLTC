using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    float _moveSpeed = 10.0f;

    public void MoveToPlayer(Vector3 to)
    {
        Vector3 direction = to - transform.position;

        transform.Translate(direction * _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, to) <= 0.2f)
        {
            MoveEnd();
        }
    }

    public virtual void MoveEnd()
    {

    }
}
