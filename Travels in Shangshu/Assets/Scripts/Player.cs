using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public float maxHP = 5f;
    public float currentHP;
    
    [Header("Movement")]
    public float speed = 8f;
    public float jumpVel = 12f;
    private bool facingRight = true;

    [Header("Outside Objects")]
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public AnimationStateChanger asc;
    

    [Header("UI Elements")]
    public HP_Bar hpBar;
    public Text hpText;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        hpBar.setMaxHealth(maxHP);
        hpText.text = currentHP.ToString();
    }

    public void Move(Vector3 offset)
    {
        if(offset != Vector3.zero){
            offset.Normalize();
            Vector3 vel = offset *= speed;
            rb2d.velocity = new Vector2(vel.x,rb2d.velocity.y);

            asc.ChangeAnimationState("Walking_Player");
            if(offset.x > 0 && !facingRight){
                //spriteRenderer.flipX = true;
                Flip();
                
            }else if(offset.x < 0 && facingRight){
                //spriteRenderer.flipX = false;
                Flip();
                
            }
            //offset *= Time.fixedDeltaTime;
            //rb2d.MovePosition(transform.position + ((offset)*speed));
        } else {
            Stop();
        }
    }
    
    public void Stop(){
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        asc.ChangeAnimationState("Idle_Player");
    }

    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVel);
    }

    private void takeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        hpBar.setHealth(currentHP);
        hpText.text = currentHP.ToString();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            takeDamage(1f);
        }
    }
}
