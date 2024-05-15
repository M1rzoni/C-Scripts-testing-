using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delayTime = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("LevelDoneScene", delayTime);
        }

    }

    void LevelDoneScene()
    {
        SceneManager.LoadScene(0);
    }



    void Update()
    {

    }
}
