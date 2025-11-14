using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{   
    [SerializeField] float loadDelay = 1f; // 골인 후 다음 씬까지 대기
    [SerializeField] ParticleSystem finishEffect; // 결승선 통과 이펙트

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player") {
            finishEffect.Play(); // 골인 이펙트
            GetComponent<AudioSource>().Play(); // 골인 사운드
            Invoke("ReloadScene",loadDelay);
           
        }    
    }

    // 다음 스테이지로 이동 (마지막이면 GameClear)
    void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene("GameClear");
        }
        else 
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        
    }

}
