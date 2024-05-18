using Scripts.Infrastructure.Factory;
using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure.States
{
    internal class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
            _gameFactory.CreateHud();

            CameraFollow(player);

            _stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject player)
        {
            Camera.main
            .GetComponent<CameraFollow>()
            .Follow(player);
        }
    }
}
