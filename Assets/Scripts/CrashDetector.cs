using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControlls();
            crashEffect.Play();
            if (count == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                count++;
            }

            Invoke(nameof(RealodScene), delayTime);
        }
    }

    void RealodScene()
    {
        SceneManager.LoadScene(0);
    }

}
