﻿using Scripts.Data;

namespace Scripts.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}