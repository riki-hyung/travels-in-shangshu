using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Outside Objects")]
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public GameObject HeartPrefab;
    
    public float hitPoints = 10f;
    public float currentElement = 0;
    public float totalDamage;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector3 offset)
    {
        if(offset != Vector3.zero)
        {
            offset.Normalize();
            Vector3 vel = offset *= speed;
            rb2d.velocity = new Vector2(vel.x, rb2d.velocity.y);

            if(offset.x < 0){
                spriteRenderer.flipX = true;
            } else {
                spriteRenderer.flipX = false;
            }
        } 
        else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    public void moveToward(Vector3 position)
    {
        Move(position - transform.position);
    }

    public void takeDamage(float damage, float elementID)
    {
        totalDamage = damage;
        if(currentElement == 0 && elementID != 0)
        {
            // Set element
            currentElement = elementID;
        } else if(currentElement == 1 && elementID == 2)
        {
            // Forward Vaporize
            totalDamage = totalDamage * 2f;
            currentElement = 0;
        } else if(currentElement == 1 && elementID == 3)
        {
            // Reverse Melt
            totalDamage = totalDamage * 1.5f;
            currentElement = 0;
        } else if(currentElement == 2 && elementID == 1)
        {
            // Reverse Vaporize
            totalDamage = totalDamage * 1.5f;
            currentElement = 0;
        } else if(currentElement == 2 && elementID == 3)
        {
            // Frozen
            currentElement = 0;
        } else if(currentElement == 3 && elementID == 1)
        {
            // Forward Melt
            totalDamage = totalDamage * 2f;
            currentElement = 0;
        } else if(currentElement == 3 && elementID == 1)
        {
            // Frozen
            currentElement = 0;
        }

        hitPoints -= totalDamage;
        if(hitPoints <= 0)
        {
            Instantiate(HeartPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
