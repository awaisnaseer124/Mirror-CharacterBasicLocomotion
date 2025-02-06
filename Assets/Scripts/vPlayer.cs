using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class vplayer : NetworkBehaviour
{

    private vThirdPersonCamera thirdPersonCamera;
    [SerializeField] private GameObject thirdPersonCameraPrefab;

    public override void OnStartAuthority()
    {
        GameObject vCameraObj = Instantiate(thirdPersonCameraPrefab);
        thirdPersonCamera = vCameraObj.GetComponent<vThirdPersonCamera>();
        thirdPersonCamera.SetTarget(transform);
    }
   
}
