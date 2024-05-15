using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    internal class LoadLevelState : IPayloadedState<string>
    {
        private const string PlayerPath = "Character/Player";
        private const string HudPath = "HUD/HUD";
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
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
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            GameObject player = Instantiate(PlayerPath, initialPoint.transform.position);

            Instantiate(HudPath);

            CameraFollow(player);

            _stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject player)
        {
            Camera.main
            .GetComponent<CameraFollow>()
            .Follow(player);
        }

        private static GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 point)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, point, Quaternion.identity);
        }
    }
}
