using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;

    public Player player;    

    // Update is called once per frame
    void FixedUpdate()
    {
        player.Move(new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed);
    }
}
