﻿using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 point);
    }
}