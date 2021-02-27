using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMananger : MonoBehaviour
{
    float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 55)
        {
            SceneManager.LoadScene("Ativdadee2");
        }
    }
}
