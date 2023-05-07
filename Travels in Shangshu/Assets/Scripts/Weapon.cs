using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject boltPrefab;

    [Header("Properties")]
    public float damage = 1f;
    public float projectileSpeed = 20f;
    public float projectileSize = 1f;
    public int weaponID = 1;
    public float gravity = 0;
    // Element IDs
    // 0 = Normal, 1 = Fire, 2 = Water, 3 = Ice
    public float elementID = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(weaponID < 4)
            {
               weaponID++;
            } else {
                weaponID = 1;
            }

            switch(weaponID)
            {
                case 4:
                    damage = 2f;
                    projectileSpeed = 30f;
                    gravity = 0;
                    elementID = 3f;
                    projectileSize = 0.5f;
                    break;
                case 3:
                    damage = 1f;
                    projectileSpeed = 5f;
                    gravity = 0;
                    elementID = 2f;
                    projectileSize = 1f;
                    break;
                case 2:
                    damage = 2f;
                    projectileSpeed = 10f;
                    gravity = 1f;
                    elementID = 1f;
                    projectileSize = 2f;
                    break;
                case 1:
                    damage = 1f;
                    projectileSpeed = 20f;
                    gravity = 0;
                    elementID = 0;
                    projectileSize = 0.75f;
                    break;
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(boltPrefab, firePoint.position, Quaternion.identity);
        bullet.transform.localScale = Vector3.one * projectileSize;
        if(elementID == 3)
        {
            bullet.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if(elementID == 2)
        {
            bullet.GetComponent<SpriteRenderer>().color = new Color(0, 1f, 1f);
        }
        else if(elementID == 1)
        {
            bullet.GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0);
        }
        bullet.GetComponent<Bolt>().Launch(transform.rotation, projectileSpeed, damage, elementID);
        Destroy(bullet, 10f);
    }
}
