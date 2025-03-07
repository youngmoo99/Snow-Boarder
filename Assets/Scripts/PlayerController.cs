using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField]
    float torqueAmount = 1f;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) { //왼쪽 방향키를 누르면 회전
            rb2d.AddTorque(torqueAmount); 
        } else if (Input.GetKey(KeyCode.RightArrow)) { //오른쪽 방향키를 누르면 회전
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
