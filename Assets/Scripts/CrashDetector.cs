using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField]
    float loadDelay = 0.1f;
    [SerializeField]
    ParticleSystem crashEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Ground") {
            crashEffect.Play();
            Invoke("ReloadScene",loadDelay);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
