﻿namespace FunctionalVarietyTracker.WPF.Contracts.Services
{
    public interface IPersistAndRestoreService
    {
        void RestoreData();

        void PersistData();
    }
}
