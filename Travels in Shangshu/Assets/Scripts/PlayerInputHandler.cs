using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Player player;    

    // Update is called once per frame
    void Update()
    {
        player.Move(new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }
    }
}
