using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        EnemyDamage(collision);
        DestroyFireball();
    }

    private void EnemyDamage(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(damage);
        }
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    
    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    void Update()
    {
        
    }
}
