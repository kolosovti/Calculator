using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace App.GlobalCanvas
{
    [CreateAssetMenu(fileName = "GlobalCanvasInstaller", menuName = "Installers/GlobalCanvasInstaller")]
    public class GlobalCanvasInstaller : ScriptableObjectInstaller<GlobalCanvasInstaller>
    {
        public GameObject GlobalCanvasPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Canvas>().FromComponentInNewPrefab(GlobalCanvasPrefab)
                .AsSingle().NonLazy();
        }
    }
}