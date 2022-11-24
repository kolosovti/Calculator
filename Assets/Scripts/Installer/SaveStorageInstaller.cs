using System.Collections;
using System.Collections.Generic;
using App.SaveStorage;
using UnityEngine;
using Zenject;

namespace App.SaveStorage
{
    [CreateAssetMenu(fileName = "SaveStorageInstaller", menuName = "Installers/SaveStorageInstaller")]
    public class SaveStorageInstaller : ScriptableObjectInstaller<SaveStorageInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerPrefsSaveStorage>().AsSingle();
        }
    }
}