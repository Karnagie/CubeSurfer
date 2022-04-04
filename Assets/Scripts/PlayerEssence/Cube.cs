using System;
using DG.Tweening;
using UnityEngine;

namespace PlayerEssence
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public float Height => transform.localScale.y;

        public event Action<Cube> OnCubeEntered;
        public event Action<Cube> OnBreaking;
        
        private void OnCollisionEnter(Collision collision)
        {
            Cube cube;
            if (collision.gameObject.TryGetComponent(out cube))
            {
                OnCubeEntered?.Invoke(cube);
            }

            if (collision.gameObject.CompareTag($"Wall"))
            {
                if (Physics.Raycast(transform.position, transform.forward, out var hit, Height*1.1f, LayerMask.GetMask($"Wall")))
                {
                    transform.SetParent(null);
                    _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    OnBreaking?.Invoke(this);
                }
            }
            
            if (collision.gameObject.CompareTag($"Lava"))
            {
                transform.SetParent(null);
                transform.DOScale(0, 0.5f);
                OnBreaking?.Invoke(this);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position+transform.forward);
        }
    }
}