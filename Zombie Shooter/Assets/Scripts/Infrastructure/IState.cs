namespace Scripts.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
