using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKey (KeyCode.A))
        {
            rb.velocity=new Vector2(-2f,0f);
        }else if(Input.GetKey(KeyCode.S))
        {
            rb.velocity=new Vector2(2f,0f);
        }else{
            rb.velocity=new Vector2(0f,0f);
        }
    }
}
