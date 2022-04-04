using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace PlayerEssence
{
    public class CubePool : MonoBehaviour
    {
        [SerializeField] private float _heightMovingSpeed = 0.1f;
        [SerializeField] private float _gravity = 1f;
        [SerializeField] private List<Cube> _cubes;
        [SerializeField] private Transform _view;

        public event Action OnOutOfCubes;
        
        private List<Cube> _cubeCache;
        private int _wallsMask;
        private int _combinedMask;
        
        private void Awake()
        {
            _wallsMask = LayerMask.GetMask($"Wall");
            _combinedMask = _wallsMask;
            _cubes = new List<Cube>();
            _cubeCache = new List<Cube>();
        }

        private void Update()
        {
            
            if (!Physics.Raycast(_view.position+Vector3.up, Vector3.down, CalculateHeight()+1.01f, _combinedMask))
            {
                _view.transform.position -= Vector3.up*_gravity*Time.deltaTime;
            }
        }

        public void AddCube(Cube cube)
        {
            if (_cubeCache.Contains(cube)) return;
            cube.transform.SetParent(_view);
            cube.transform.localRotation = Quaternion.identity;
            cube.transform.localPosition = Vector3.up*(-CalculateHeight()-cube.Height/2);
            cube.OnCubeEntered += AddCube;
            cube.OnBreaking += RemoveCube;
            _cubes.Add(cube);
            _cubeCache.Add(cube);
            MoveHeight();
        }

        private void RemoveCube(Cube cube)
        {
            _cubes.Remove(cube);
            if (_cubes.Count == 0)
            {
                OnOutOfCubes?.Invoke();
                enabled = false;
            }
        }

        private void MoveHeight()
        {
            float height = CalculateHeight();
            _view.DOLocalMoveY(height, _heightMovingSpeed);
        }

        private float CalculateHeight()
        {
            float height = 0;
            _cubes.ForEach((cube1 => height += cube1.Height));
            return height;
        }
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out Cube cube))
            {
                AddCube(cube);
            }
        }
    }
}