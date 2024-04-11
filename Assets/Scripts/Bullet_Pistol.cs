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
    float LifeTime;
    Vector3 Direction;   
    [SerializeField]
    Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        // 데미지 세팅
        LifeTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            LifeTime -= Time.deltaTime;

            if (LifeTime < 0f)
            {
                BulletSpawner.Instance.PushToPool("Bullet_Pistol", gameObject);
            }
        }               
    }

    
    private void FixedUpdate()
    {
        if (Target != null)
        {
            _rigidbody.AddForce(Direction * Speed, ForceMode2D.Impulse);
        }
    }
    

    public void SetTarget(Transform _target)
    {
        Target = _target;

        Vector3 _distance = Target.position - transform.position;
        Direction = _distance.normalized;        

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
