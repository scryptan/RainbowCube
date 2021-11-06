using System;
using RainbowCube.Player;
using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 15f;
        private BulletEffect _bulletEffect;
        private Vector3 _direction;

        public void Init(Vector3 direction, BulletEffect bulletEffect)
        {
            _direction = direction;
            _bulletEffect = bulletEffect;
            Destroy(gameObject, 15);
        }

        private void Update()
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            Affect(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Affect(other);
        }

        private void OnTriggerStay(Collider other)
        {
            Affect(other);
        }

        private void Affect(Collider other)
        {
            switch (_bulletEffect.affectFor)
            {
                case AffectFor.Enemy:
                    var affectable = other.GetComponent<IAffectable>();
                    affectable?.GetAffect(_bulletEffect);
                    break;
                case AffectFor.Player:
                    var player = other.GetComponent<PlayerTag>();
                    player?.Affect(_bulletEffect);
                    break;
                case AffectFor.Environment:
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Destroy(gameObject);
        }
    }
}