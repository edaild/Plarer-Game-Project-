using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerscipt : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool WDown;


    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();

    }
        void Update()
        {
        GetInput();
        Move();
        Turn();
        }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        WDown = Input.GetButton("wolk");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (WDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWolk", WDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
    

}


