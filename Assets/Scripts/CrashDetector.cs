using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("RealodScene", delayTime);
        }
    }

    void RealodScene()
    {
        SceneManager.LoadScene(0);
    }


    void Update()
    {

    }
}
