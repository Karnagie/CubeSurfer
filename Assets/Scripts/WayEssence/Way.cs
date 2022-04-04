using System.Linq;
using UnityEngine;

namespace WayEssence
{
    public class Way : MonoBehaviour, IWay
    {
        [SerializeField] private WayPoint[] _points;

        private int _currentIndex = 0;

        public Vector3[] Positions { get => _points.Select(c => c.Position).ToArray(); }

        private void Start()
        {
            var s = _points.Select(c => c.Position).ToArray();
        }

        public void Next()
        {
            if(_currentIndex+1 >= _points.Length) return;
            _currentIndex++;
        }

        private void OnDrawGizmos()
        {
            if (_points == null || _points.Length < 2) return;

            Gizmos.color = Color.blue;
            for (int i = 1; i < _points.Length; i++)
            {
                Gizmos.DrawLine(_points[i - 1].Position, _points[i].Position);
            }
        }
    }
}