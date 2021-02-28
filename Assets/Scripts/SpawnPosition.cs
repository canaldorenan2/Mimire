using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnPosition : NetworkBehaviour
{
    [SerializeField]Transform spawn1;
    [SerializeField]Transform spawn2;

    public void SetPosition(PlayerMove player, bool isClient)
    {
        if (isClient)
        {
            player.transform.position = spawn1.position;
        }
        else
        {
            player.transform.position = spawn2.position;
        }
    }
}
