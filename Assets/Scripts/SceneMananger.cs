using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMananger : MonoBehaviour
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 55)
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
