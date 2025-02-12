﻿using Project.Infrastructure.Services.SaveSystem.Data;
using Project.Infrastructure.Services.SaveSystem.PersistentProgressService;
using Zenject;

namespace Project.Infrastructure.Services.SaveSystem.SaveHandler
{
    public abstract class SaveHandler : ISaveHandler
    {
        [Inject]
        private void Construct(ISaveLoadService saveLoadService, IPersistentProgressService progressService)
        {
            saveLoadService.Register(this);
            LoadProgress(progressService.Progress);
        }

        public abstract void LoadProgress(GameProgress progress);

        public abstract void UpdateProgress(GameProgress progress);
    }
}