using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField]
    float torqueAmount = 1f;
    [SerializeField]
    float boostSpeed = 30f;
    [SerializeField]
    float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost(); 
        }
    }
    public void DisableControls()  //컨트롤 중지
    {
        canMove = false;
    }
    private void RespondToBoost()
    {
        //위쪽 방향키를 누를시 스피드업 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        } 
        else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
     }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        { //왼쪽 방향키를 누르면 회전
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        { //오른쪽 방향키를 누르면 회전
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
