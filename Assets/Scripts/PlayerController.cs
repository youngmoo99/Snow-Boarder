using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float torqueAmount = 1f; // 회전 토크 크기(좌/우)
    [SerializeField] float boostSpeed = 30f; // 가속 시 표면 속도
    [SerializeField] float baseSpeed = 20f; // 기본 표면 속도
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D; // 바닥 이동 벨트(슬로프) 속도 제어
    bool canMove = true; // 조작 가능 여부 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {   
        if (canMove)
        {
            RotatePlayer(); // 좌/우 기울여 회전
            RespondToBoost();  // 가속/기본 속도 전환
        }
    }

    /// <summary>
    /// CrashDetector에서 호출하여 조작 비활성화
    /// </summary>
    public void DisableControls()  
    {
        canMove = false;
    }

    /// <summary>
    /// ↑ 키로 가속, 아니면 기본 속도 유지
    /// SurfaceEffector2D는 바닥이 캐릭터를 움직이는 느낌을 제공
    /// </summary>   
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

    /// <summary>
    /// 좌/우 화살표로 플레이어를 회전시켜 보드 각도 조절
    /// (양수 토크 = 반시계, 음수 토크 = 시계)
    /// </summary>
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {   //왼쪽 방향키를 누르면 회전
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {   //오른쪽 방향키를 누르면 회전
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
