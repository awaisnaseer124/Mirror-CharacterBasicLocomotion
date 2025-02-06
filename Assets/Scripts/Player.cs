using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private Vector3 movement = new Vector3();
    // Start is called before the first frame update
    public bool hasAuthority = false;
    // Update is called once per frame
    [Client]
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        CmdMove();
    //     transform.Translate(movement);

    }

    [Command]
    void CmdMove()
    {
        //server validation
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove() => transform.Translate(movement);

}
