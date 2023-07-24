using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //---Bound in Unity---
    public bool Sticky; //if true, button needs something on it

    [SerializeField]
    private GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //allows player to press button if doesn't need held down
        if (collision.gameObject.tag == "Player" && Sticky)
        {
            Door.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //kinda want to keep multiplayer an option so it should check for bofa
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Player")
        {
            Door.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!Sticky) Door.SetActive(true);
    }
}
