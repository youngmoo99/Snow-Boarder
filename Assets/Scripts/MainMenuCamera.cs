using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f; // 초당 이동량 
    [SerializeField] float moveDistance = 10f; // 오른쪽으로 이동 후 리셋할 거리

    private Vector3 startPosition; // 처음 위치
    private float movedDistance = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {   
        // 오른쪽으로 일정 속도로 이동
        float step = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * step);

        movedDistance += step;
        
        // 설정 거리만큼 이동하면 원점으로 리셋(무한 루프 느낌)
        if (movedDistance >= moveDistance)
        {
            transform.position = startPosition;
            movedDistance = 0f;
        }
    }
}
