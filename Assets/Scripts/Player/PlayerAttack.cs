using System;
using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube.Player
{
    [RequireComponent(typeof(BulletSpawner))]
    public class PlayerAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float timeBetweenFire = .3f;
        private float tempTimeBetweenFire;
        private BulletSpawner _bulletSpawner;

        private void OnEnable()
        {
            _bulletSpawner = GetComponent<BulletSpawner>();
        }

        public void Update()
        {
            tempTimeBetweenFire = Mathf.Clamp(tempTimeBetweenFire - Time.deltaTime, -1, timeBetweenFire);
        }

        public void Attack(BulletEffect effect)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, float.MaxValue, _layerMask) && tempTimeBetweenFire <= 0)
            {
                _bulletSpawner.SpawnBullet(hit.point, effect);
                tempTimeBetweenFire = timeBetweenFire;
            }
        }
    }
}