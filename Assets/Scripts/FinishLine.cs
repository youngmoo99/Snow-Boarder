using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{   
    [SerializeField]
    float loadDelay = 1f;
    [SerializeField]
    ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player") {
            finishEffect.Play(); // 골인 이펙트
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene",loadDelay);
           
        }    
    }

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
