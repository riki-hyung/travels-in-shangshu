using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitPoints = 10f;
    public float currentElement = 0;
    public float totalDamage;

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
            Destroy(gameObject);
        }
    }
}
