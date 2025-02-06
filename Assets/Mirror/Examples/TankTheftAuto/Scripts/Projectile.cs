using UnityEngine;
using Mirror;

namespace Mirror.Examples.TankTheftAuto
{
    public class Projectile : NetworkBehaviour
    {
        public float destroyAfter = 2;
        public Rigidbody rigidBody;
        public float force = 1000;

        public override void OnStartServer()
        {
            Invoke(nameof(DestroySelf), destroyAfter);
        }

        void Start()
        {
            rigidBody.AddForce(transform.forward * force);
        }

        [Server]
        void DestroySelf()
        {
            NetworkServer.Destroy(gameObject);
        }

        // Use ServerCallback to ensure this is only executed on the server
        [ServerCallback]
        void OnTriggerEnter(Collider co)
        {
            TankController tankController = co.GetComponent<TankController>();
            if (tankController != null && tankController.netIdentity != netIdentity)
            {
                Debug.Log("Apply Damage to " + co.gameObject.name);
                // ApplyDamage(tankController); //without rpc call
                RpcApplyDamage(tankController.netId); //rpc call exaple
            }

            DestroySelf();
        }
        // We can call the damage application logic directly on the server
        [Server]
        void ApplyDamage(TankController tankController)
        {
            tankController.health -= 1;
        }

        [ClientRpc]
        public void RpcApplyDamage(uint _id)
        {
            if (NetworkServer.spawned.TryGetValue(netId, out NetworkIdentity identity))
            {
                TankController tankController = identity.GetComponent<TankController>();
                if (tankController != null)
                {
                    Debug.Log("RPC: Applying damage to " + tankController.gameObject.name);
                    tankController.health -= 1;
                }
            }
          

        }
    }
}
