﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usado para online
using UnityEngine.Networking;

// herda de network
public class PlayerMove : NetworkBehaviour
{
    float moveSpeed = 15f;
    float horizontal;
    float vertical;
    bool firstShot;
    int vida = 0;

    [SerializeField]bool dancando;
    [SerializeField]float tempoDanca;

    public ParticleSystem particulas;
    public GameObject Right;
    public GameObject Left;

    public GameObject bullet;

    Material lucian1;

    public int score;

    public Animator animator;

    public Camera cam;

    public int rotacao = 90;

    private void Start()
    {
        firstShot = false;
        cam.gameObject.SetActive(true);
        vida = 100;
    }

    private void Update()
    {

        if (vida < 1)
        {
            animator.SetBool("Death", true);
        }

        //if (isLocalPlayer) // variavel de networkbehaviour
        {
            ControlaRotacao();

            ControlaMovimentacao();

            if (Input.anyKey)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Dance", false);
                tempoDanca = 0;
                dancando = false;

                ControlaAnimacao();
            }
            else
            {

                animator.SetBool("Run", false);
                animator.SetBool("Atacar1", false);
                animator.SetBool("Atacar2", false);
                animator.SetBool("Ultimate", false);
                firstShot = true;

                if (dancando)
                {
                    tempoDanca += Time.deltaTime;

                    if (tempoDanca > 3.0f)
                    {
                        animator.SetBool("Dance", false);
                        tempoDanca = 0;
                        dancando = false;
                    }
                }
                else
                {
                    tempoDanca = 0;
                    animator.SetBool("Idle", true);
                }
            }

            ControlaEfeitos();

            if (Input.GetKeyDown("c"))
            {
                lucian1 = Resources.Load("Lucian/Lucian1", typeof(Material)) as Material;
                Debug.Log("Oi");
                this.transform.GetChild(5).GetComponent<SkinnedMeshRenderer>().materials[0] = lucian1;
            }
            if (Input.GetKeyDown("v"))
            {
                lucian1 = Resources.Load("Lucian/LucianBase", typeof(Material)) as Material;
                Debug.Log("Oi");
                this.transform.GetChild(5).GetComponent<SkinnedMeshRenderer>().materials[0] = lucian1;
            }
        }
    }

    private void ControlaEfeitos()
    {
        if (animator.GetBool("Atacar1") == true)
        {
            if (firstShot)
            {
                //Vector3 posInstanciaBullet = new Vector3(this.transform.forward.x , this.transform.forward.y, this.transform.forward.z);

                // Instancia o prefabe da bala
                GameObject bulletPrefabe = Instantiate(bullet, Right.transform.position, this.transform.localRotation);
                
                // Instancia o prefabe das particulas
                ParticleSystem shotEfect = Instantiate(particulas, Right.transform.position, this.transform.localRotation);
                Destroy(shotEfect.gameObject, 1);

                // Ajusta o prefabe
                bulletPrefabe.transform.Rotate(rotacao, 0, 0);

                bulletPrefabe.GetComponent<Rigidbody>().AddForce(this.transform.forward * 10000);

                firstShot = false;
            }
        }


        if (animator.GetBool("Atacar2") == true)
        {
            if (firstShot)
            {
                //Vector3 posInstanciaBullet = new Vector3(this.transform.forward.x , this.transform.forward.y, this.transform.forward.z);

                // Instancia o prefabe da bala
                GameObject bulletPrefabe = Instantiate(bullet, Left.transform.position, this.transform.localRotation);

                // Instancia o prefabe das particulas
                ParticleSystem shotEfect = Instantiate(particulas, Left.transform.position, this.transform.localRotation);
                Destroy(shotEfect.gameObject, 1);

                // Ajusta o prefabe
                bulletPrefabe.transform.Rotate(90, 0, 0);

                bulletPrefabe.GetComponent<Rigidbody>().AddForce(this.transform.forward * 10000);

                firstShot = false;
            }
        }



    }

    void ControlaMovimentacao()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 posicao = new Vector3(horizontal, 0, vertical);

        transform.Translate(posicao * Time.deltaTime * moveSpeed);

        Debug.Log("w");

    }


    void ControlaRotacao()
    {
        transform.Rotate(0,Input.GetAxisRaw("Mouse X"),0);
    }

    private void ControlaAnimacao()
    {
        if ((horizontal != 0) || (vertical != 0))
        {
            animator.SetBool("Run", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Atacar1", true);

            animator.SetBool("Atacar2", false);
        }

        if (Input.GetKeyDown("h"))
        {
            Debug.Log("Teste");
            animator.SetBool("Dance", true);
            dancando = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Atacar2", true);

            animator.SetBool("Atacar1", false);

            //firstShot = true;
        }

        if (Input.GetKeyDown("r"))
        {
            animator.SetBool("Ultimate", true);
            firstShot = true;
        }

        
    }
}
