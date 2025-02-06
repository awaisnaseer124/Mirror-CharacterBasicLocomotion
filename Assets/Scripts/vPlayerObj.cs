using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class vPlayerObj : NetworkBehaviour
{
    [HideInInspector] public vThirdPersonCamera thirdPersonCamera;
    [SerializeField] private GameObject thirdPersonCameraPrefab;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();

        if (!isLocalPlayer)
            return;

        // thirdPersonCamera.gameObject.SetActive(true) ;

        /*  FindObjectOfType<vThirdPersonCamera>().SetMainTarget(transform);*/
        GameObject vCameraObj = Instantiate(thirdPersonCameraPrefab);
        vCameraObj.name = transform.gameObject.name + "Camera";
        thirdPersonCamera = vCameraObj.GetComponent<vThirdPersonCamera>();
        thirdPersonCamera.SetMainTarget(transform);
    }


    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<vHealth>();
        if (health != null && !health.isLocalPlayer)
        {
            Debug.Log("not a local player");
            // health.ApplyDamage(5);
            ApplyDamage(health);
        }

    }

    [Server]
    void ApplyDamage(vHealth _health)
    {
        _health.ApplyDamage(5);
    }
}
