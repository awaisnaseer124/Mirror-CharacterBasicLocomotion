using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class WinTrigger : MonoBehaviour
{
    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<vPlayerObj>();
        if (player != null && player.isLocalPlayer)
        {
            UIManager.instance.ShowGameOverPanel(true);
        }
    }
}
