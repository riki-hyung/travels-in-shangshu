using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, Interacting
{
    [SerializeField] private SpriteRenderer interactSprite;
    private Transform playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Near())
        {
            Interact();
        }

        if(interactSprite.gameObject.activeSelf && !Near())
        {
            interactSprite.gameObject.SetActive(false);
        }
        else if(!interactSprite.gameObject.activeSelf && Near())
        {
            interactSprite.gameObject.SetActive(true);
        }
    }

    public abstract void Interact();

    private bool Near()
    {
        if(Vector2.Distance(playerLocation.position, transform.position) < 3f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
