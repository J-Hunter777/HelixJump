using System;
using UnityEngine;

namespace Assets.Scripts.Structur
{
    [System.Serializable]
    public class Vector3Curves
    {
        [SerializeField] private AnimationCurve _xCurve;
        [SerializeField] private AnimationCurve _yCurve;
        [SerializeField] private AnimationCurve _zCurve;

        public AnimationCurve XCurve => _xCurve;
        public AnimationCurve YCurve => _yCurve;
        public AnimationCurve ZCurve => _zCurve;

    }

}

