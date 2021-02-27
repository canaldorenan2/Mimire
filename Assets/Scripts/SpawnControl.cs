using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnControl : NetworkBehaviour
{
    //public GameObject spawnLocate;
    public GameObject gemaPrefabe;

    public bool instanciado;
    public GameObject instancia;

    Vector3 spawnPosition = new Vector3(0, 3, 0);

    int pos, posaux;
    public override void OnStartServer()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        instanciado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Destroy(instancia);
            instanciado = false;
        }

        if (!instanciado)
        {
            posaux = pos;
            while(pos == posaux)
            {
                pos = Random.Range(1, 6);
            }

            //Debug.Log("Var pos: " + pos);
            switch (pos)
            {
                case 1:
                    spawnPosition.x = 82;
                    spawnPosition.z = 350;
                    break;

                case 2:
                    spawnPosition.x = 198;
                    spawnPosition.z = 8;
                    break;
                case 3:
                    spawnPosition.x = 270;
                    spawnPosition.z = 161;
                    break;
                case 4:
                    spawnPosition.x = 395;
                    spawnPosition.z = 131;
                    break;
                case 5:
                    spawnPosition.x = 390;
                    spawnPosition.z = 360;
                    break;

            }
            
            instancia = Instantiate(gemaPrefabe, spawnPosition, this.transform.rotation);

            instanciado = true;
        }

        
    }
}
