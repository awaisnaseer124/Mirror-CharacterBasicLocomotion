using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class vHealth : NetworkBehaviour
{
   [SyncVar] public int heatlh = 100;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    public void ApplyDamage(int _damageAmount)
    {
        heatlh -= _damageAmount;
    }
}
