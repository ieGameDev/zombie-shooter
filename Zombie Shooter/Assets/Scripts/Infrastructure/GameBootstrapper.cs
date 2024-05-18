using Scripts.Infrastructure.States;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] public LoadingCurtain _curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}