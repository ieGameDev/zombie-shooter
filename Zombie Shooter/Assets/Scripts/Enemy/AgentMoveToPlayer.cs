using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private const float MinimalDistance = 1f;

        public NavMeshAgent Agent;

        private Transform _playerTransform;
        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.PlayerGameObject != null)
                InitializePlayerTransform();
            else
                _gameFactory.PlayerCreated += PlayerCreated;
        }

        private void Update()
        {
            if (_playerTransform != null && PlayerNotReached())
                Agent.destination = _playerTransform.position;
        }

        private void PlayerCreated() => 
            InitializePlayerTransform();

        private void InitializePlayerTransform() =>
            _playerTransform = _gameFactory.PlayerGameObject.transform;

        private bool PlayerNotReached() =>
            Vector3.Distance(Agent.transform.position, _playerTransform.position) >= MinimalDistance;
    }
}
