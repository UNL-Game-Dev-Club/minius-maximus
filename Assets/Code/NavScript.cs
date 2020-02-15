using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NavScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();
        transform.position=new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(-Mathf.Sqrt(2),Mathf.Sqrt(2));
            }
            else if(!Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(-Mathf.Sqrt(2),-Mathf.Sqrt(2));
            }else if(!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(-2f,0f);
            }
        }
        else if(Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
             if(Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(Mathf.Sqrt(2),Mathf.Sqrt(2));
            }
            else if(!Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(Mathf.Sqrt(2),-Mathf.Sqrt(2));
            }else if(!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
            {
                rb.velocity=new Vector2(2f,0f);
            }
        }
        else if(Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S)
                &&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            rb.velocity=new Vector2(0f,2f);
        }
        
        else if(!Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S)
                &&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
                     rb.velocity=new Vector2(0f,-2f); 
        }
        else{
            rb.velocity=new Vector2(0f,0f);
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="overworldEnemy")
        {
            
        }
    }
}
