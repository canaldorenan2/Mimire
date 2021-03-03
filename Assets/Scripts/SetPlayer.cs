using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetPlayer : NetworkBehaviour
{
    public GameObject senna;
    public GameObject lucian;


    public override void OnStartLocalPlayer()
    {

        if (!isClient)
        {
            Debug.Log("Deve spawnar a Senna");
            Instantiate(senna, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Deve spawnar o Lucian");
            Instantiate(lucian, transform.position, transform.rotation);
        }

        Destroy(this.gameObject, 0.1f);

    }
}
