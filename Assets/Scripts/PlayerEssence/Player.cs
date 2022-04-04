using BusEvents;
using BusEvents.Handlers;
using DG.Tweening;
using UnityEngine;
using WayEssence;
using Zenject;

namespace PlayerEssence
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxOffset = 1;
        [SerializeField] private float _swipeMultiplier = 1;
        [SerializeField] private Transform _view;
        [SerializeField] private CubePool _cubePool;

        private PlayerController _playerController;

        [Inject] private IWay _way;

        private void Awake()
        {
            _cubePool.OnOutOfCubes += Lose;
            _playerController = new PlayerController();
            transform.DOPath(_way.Positions, _way.Positions.Length*_speed)
                    .OnComplete(() => Win())
                    .onWaypointChange += 
                value => transform.LookAt(_way.Positions[value]);
        }

        private void Win()
        {
            EventBus.RaiseEvent((IGameStateHandler handler) => handler.Win());
        }

        private void Lose()
        {
            transform.DOKill();
            EventBus.RaiseEvent((IGameStateHandler handler) => handler.Lose());
        }

        private void Update()
        {
            _playerController.Update();
            _view.transform.position += (Quaternion.Euler(0,90,0)*_view.transform.forward)*_playerController.GetOffset()*_swipeMultiplier;
            CalculatePosition();
        }

        private void CalculatePosition()
        {
            Vector3 pos = _view.transform.localPosition;
            pos.x = Mathf.Min(pos.x, _maxOffset);
            pos.x = Mathf.Max(pos.x, -_maxOffset);
            _view.transform.localPosition = pos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position-Vector3.forward*_maxOffset, transform.position+Vector3.forward*_maxOffset);
        }
    }
}