﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NavScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision col;
    Vector3 moveV=new Vector3(0,0,0);
    
    float xv=0;
    float yv=0;
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();
        transform.position=new Vector3(1,1,0);
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            xv=-(float)0.2;
        }
        else if(!Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D))
        {
            xv=(float)0.2;
        }else
        {
            if(xv>0.0){
                xv+=-xv;
            }
            if(xv<0.0){
                xv+=-xv;
            }
        }
        moveV=new Vector3(xv,yv,0);
        transform.position+=moveV;

    }

    void OnCollisionEnter(Collision col)
    {
        this.col=col;
        if(col.gameObject.name=="floor")
        {   
            yv=0;
        }else{
            yv--;
        }
    }
}
