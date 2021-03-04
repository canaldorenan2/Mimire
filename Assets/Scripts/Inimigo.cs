using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class Inimigo : NetworkBehaviour
{

    public int vida;
    [SerializeField]Animator animator;
    public Transform target;

    NavMeshAgent agent;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        timer = 0;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (vida < 1)
        {
            animator.SetBool("Death", true);
            Destroy(this, 2);
        }

        if (timer > 3)
        {
           agent.SetDestination(target.transform.position);
           timer = 0;
           //transform.Translate(10 * Time.deltaTime, 0, 0);
        }


        timer+= Time.deltaTime;
        */


        agent.SetDestination(target.position);
    }
}
