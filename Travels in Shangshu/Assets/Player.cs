using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;

    [Header("Outside Objects")]
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 offset)
    {
        if(offset != Vector3.zero){
            offset.Normalize();
            offset *= Time.fixedDeltaTime;
            rb2d.MovePosition(transform.position + ((offset)*speed));
            if(offset.x > 0){
                spriteRenderer.flipX = true;
            }else{
                spriteRenderer.flipX = false;
            }
        }
    }
    
    public void Stop(){
        Move(Vector3.zero);
    }
}