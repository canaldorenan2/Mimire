using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Inimigo : NetworkBehaviour
{

    public int vida;
    [SerializeField]Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida > 1)
        {
            animator.SetBool("Death", true);
            Destroy(this, 2);
        }
    }
}
