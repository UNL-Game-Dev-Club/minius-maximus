using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NavScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision col;
    Vector3 moveV=new Vector3(0,0,0);
    private bool dcol=false;
    GameObject diaManagerObj;
    DialogueManager diaManag;

    [SerializeField] float velocity = 0.2f;
    
    float xv=0;
    float yv=0;
    // Start is called before the first frame update
    void Start()
    {
        diaManagerObj= GameObject.Find("DialogueManager");
        diaManag=diaManagerObj.GetComponent(typeof(DialogueManager)) as DialogueManager;
        rb=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
       if(diaManag.dialogueStarted==false){
            move();
       } 
    }


    public void move(){
         if(!dcol){
            yv=(float)(yv*0.90);
        }
        if(Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            xv=- velocity;
        }
        else if(!Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D))
        {
            xv= velocity;
        }else
        {
            if(xv>0.0){
                xv+=-xv;
            }
            if(xv<0.0){
                xv+=-xv;
            }
        }
        if(dcol&&Input.GetKey(KeyCode.W))
        {
            dcol=false;
            yv=(float)0.25;
        }
        moveV=new Vector3(xv,yv,0);        
        transform.position+=moveV;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name=="Floor")
        {   
            dcol=true;
        }
    }

    
}
