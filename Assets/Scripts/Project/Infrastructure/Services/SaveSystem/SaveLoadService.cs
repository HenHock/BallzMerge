using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using Project.Extensions;
using Project.Infrastructure.Services.SaveSystem.Data;
using Project.Infrastructure.Services.SaveSystem.PersistentProgressService;
using Project.Infrastructure.Services.SaveSystem.SaveHandler;
using UnityEngine;
using ILogger = Project.Infrastructure.Logger.ILogger;

namespace Project.Infrastructure.Services.SaveSystem
{
    public class SaveLoadService : ISaveLoadService, ILogger
    {
        private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, "BalzMerge.json");
        
        private readonly List<IProgressWriter> _progressWriters = new();
        private readonly List<IProgressReader> _progressReaders = new();
        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IPersistentProgressService progressService) => 
            _progressService = progressService;

        public void Register(ISaveHandler saveHandler)
        {
            _progressReaders.Add(saveHandler);
            _progressWriters.Add(saveHandler);
        }

        public void Save()
        {
            ProgressWriterUpdates();
            WriteInFile().Forget();

            this.Log("Saved data successfully");
        }

        public async UniTask Load() => 
            _progressService.Progress = await ReadFromFile();

        public void Cleanup()
        {
            _progressReaders.Clear();
            _progressWriters.Clear();
        }

        private void ProgressWriterUpdates()
        {
            foreach (var progressWriter in _progressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
        }

        private async UniTaskVoid WriteInFile()
        {
            try
            {
                string json = _progressService.Progress.ToJson();
                await File.WriteAllTextAsync(_saveFilePath, json);
                this.Log($"Data successfully written to: {_saveFilePath}");
            }
            catch (Exception e)
            {
                Debug.LogError($"Error writing to file: {e.Message}");
            }
        }

        private async UniTask<GameProgress> ReadFromFile()
        {
            try
            {
                if (!File.Exists(_saveFilePath))
                {
                    this.Log($"File does not exist: {_saveFilePath}. Initialized new progress");
                    return new GameProgress();
                }

                string json = await File.ReadAllTextAsync(_saveFilePath);

                GameProgress progress = json.FromJson<GameProgress>();
                this.Log($"Data successfully read from: {_saveFilePath}");
                return progress;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error reading from file: {ex.Message}");
            }

            return new GameProgress();
        }
    }
}