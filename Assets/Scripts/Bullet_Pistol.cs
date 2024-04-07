using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet_Pistol : MonoBehaviour
{
    Transform Target;

    float Damage = 1f;
    float Speed = 0.2f;

    private void OnEnable()
    {
        // 데미지 세팅
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed);            
        }

        if (!Target.gameObject.activeSelf)
        {
            BulletSpawner.Instance.PushToPool("Bullet_Pistol", gameObject);
        }
    }

    public void SetTarget(Transform _target)
    {
        Target = _target;

        Vector2 _distance = Target.position - transform.position;
        float _rotateZ = Mathf.Atan2(_distance.y, _distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _rotateZ + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(Damage);

            BulletSpawner.Instance.PushToPool("Bullet_Pistol", gameObject);
        }
    }


}
