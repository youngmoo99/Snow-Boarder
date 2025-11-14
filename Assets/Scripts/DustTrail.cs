using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{     
    [SerializeField] ParticleSystem dustTrail; // 설원(바닥)과 접촉 시 나오는 눈가루

    // 바닥과 '충돌' 시작하면 파티클 재생
    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Ground") 
       {
            dustTrail.Play();
       }
    }

    // 바닥과 '충돌'이 끝나면 파티클 정지
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            dustTrail.Stop();
        }
    }

}
