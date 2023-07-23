using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSet : MonoBehaviour
{

    public Animator anim;
    public int trapDmg;
    public bool playerIn;
    public movementPlayer PC;

    // Start is called before the first frame update
    void Start()
    {
        playerIn = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIn = true;
            anim.SetBool("isActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIn = false;
            anim.SetBool("isActive", false);
        }
    }

    public void DamagePlayer()
    {
        if (playerIn)
        {
            PC.health -= trapDmg;
        }
    }

}
