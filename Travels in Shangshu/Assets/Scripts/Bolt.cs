using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float damage = 0;

    // Element IDs
    // 0 = Normal, 1 = Fire, 2 = Water, 3 = Ice
    public float elementID = 0;

    public void Launch(Quaternion rotation, float speed, float newDamage, float elementType)
    {
        damage = newDamage;
        transform.rotation = rotation;
        elementID = elementType;
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.takeDamage(damage, elementID);
            }
            Destroy(gameObject);
        }
        if(hitInfo.CompareTag("Box"))
        {
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
    }
}
