using UnityEngine;
using Random = UnityEngine.Random;

namespace RainbowCube.Player
{
    public class LinersSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject linearPrefab;
    
        [SerializeField]
        private Transform forceDirectionPos;
    
        [SerializeField]
        private float force;
    
        [SerializeField]
        private float maxTimeToSpawn;

        private float timeToSpawn;

        void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                if (timeToSpawn <= 0)
                {
                    SpawnLinear();
                    timeToSpawn += maxTimeToSpawn;
                }

                timeToSpawn -= Time.deltaTime;
            }
        }

        public void SpawnLinear()
        {
            var forceDirection = forceDirectionPos.position - transform.position;
            forceDirection.Normalize();
            var currInstance = Instantiate(linearPrefab, transform.position, Quaternion.identity);
            var rb = currInstance.AddComponent<Rigidbody>();
            rb.mass = 0.1f;
            var newDir = new Vector3(forceDirection.x, Random.Range(-forceDirection.y, forceDirection.y), Random.Range(-forceDirection.z, forceDirection.z));
            rb.AddForce(newDir * force, ForceMode.Force);
            Destroy(currInstance, 30);
        }
    }
}
