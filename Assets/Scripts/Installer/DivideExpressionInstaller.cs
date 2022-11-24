using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Expression.Compute;
using UnityEngine;
using Zenject;

namespace App.Expression
{
    [CreateAssetMenu(fileName = "DivideExpressionInstaller", menuName = "Installers/DivideExpressionInstaller")]
    public class DivideExpressionInstaller : ScriptableObjectInstaller<DivideExpressionInstaller>
    {
        [Inject] private Canvas _globalCanvas;
        public GameObject ExpressionView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DivideComputeStrategy>().WhenInjectedInto<ExpressionModel>();
            Container.BindInterfacesAndSelfTo<ExpressionModel>().WhenInjectedInto<ExpressionPresenter>();

            Container.BindInterfacesAndSelfTo<ExpressionView>().FromComponentInNewPrefab(ExpressionView)
                .UnderTransform(_globalCanvas.transform)
                .AsSingle().WhenInjectedInto<ExpressionPresenter>();
            Container.BindInterfacesAndSelfTo<ExpressionPresenter>().AsSingle().NonLazy();
        }
    }
}