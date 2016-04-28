using System;
using System.Collections.Generic;
using ModestTree;

#if !ZEN_NOT_UNITY3D
using UnityEngine;
#endif


namespace Zenject
{
    public class FactoryToChoiceBinder<TContract> : FactoryFromBinder<TContract>
    {
        public FactoryToChoiceBinder(
            BindInfo bindInfo,
            BindFinalizerWrapper finalizerWrapper)
            : base(bindInfo, finalizerWrapper)
        {
        }

        // Note that this is the default, so not necessary to call
        public FactoryFromBinder<TContract> ToSelf()
        {
            Assert.IsEqual(BindInfo.ToChoice, ToChoices.Self);
            return this;
        }

        public FactoryFromBinder<TConcrete> To<TConcrete>()
            where TConcrete : TContract
        {
            BindInfo.ToChoice = ToChoices.Concrete;
            BindInfo.ToTypes = new List<Type>()
            {
                typeof(TConcrete)
            };

            return new FactoryFromBinder<TConcrete>(
                BindInfo, FinalizerWrapper);
        }
    }
}