using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField] float loadDelay = 2f; // 충돌 후 씬 전환까지 대기 시간
    [SerializeField] ParticleSystem crashEffect; // 충돌 파티클
    [SerializeField] AudioClip crashSFX; // 충돌 사운드
    bool soundSFX = true; // 중복 재생 방지

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Ground" && soundSFX) {
            // 조작 잠금
            FindObjectOfType<PlayerController>().DisableControls(); 

            // 이펙트 & 사운드 재생
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); 

            // 약간의 딜레이 후 씬 전혼
            Invoke("ReloadScene",loadDelay);

            // 재진입/ 중복 호출 방지
            soundSFX = false;
            
        }
    }

    public void ReloadScene()
    {   
        // 게임오버 씬으로 이동
        SceneManager.LoadScene("GameOver");
    }
}
