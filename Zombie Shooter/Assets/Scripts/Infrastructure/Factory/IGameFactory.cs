using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateHud();
        GameObject CreatePlayer(GameObject initialPoint);
    }
}