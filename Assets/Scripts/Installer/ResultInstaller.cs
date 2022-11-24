using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace App.Result
{
    [CreateAssetMenu(fileName = "ResultInstaller", menuName = "Installers/ResultInstaller")]
    public class ResultInstaller : ScriptableObjectInstaller<ResultInstaller>
    {
        [Inject] private Canvas _globalCanvas;
        public GameObject ResultViewPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResultModel>().WhenInjectedInto<ResultPresenter>();

            Container.BindInterfacesAndSelfTo<ResultView>().FromComponentInNewPrefab(ResultViewPrefab)
                .UnderTransform(_globalCanvas.transform)
                .AsSingle().WhenInjectedInto<ResultPresenter>();
            Container.BindInterfacesAndSelfTo<ResultPresenter>().AsSingle().NonLazy();
        }
    }
}