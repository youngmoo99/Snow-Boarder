using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField]
    float loadDelay = 2f;
    [SerializeField]
    ParticleSystem crashEffect;
    [SerializeField]
    AudioClip crashSFX;
    bool soundSFX = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Ground" && soundSFX) {
            FindObjectOfType<PlayerController>().DisableControls(); // 다른 클래스에서 변경 
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); //오디오 클립을 재생하고 오디오 소스불륨을 조정함
            Invoke("ReloadScene",loadDelay);
            soundSFX = false;
            
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
