using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Structur;
using Assets.Scripts.Phyzics.Bounce;


namespace Assets.Scripts.Phyzics.Bounce
{
    public class BounceEffects
    {
        private readonly Rigidbody _rigidbody;
        private readonly BounceData _data;
        private readonly Vector3Curves _scaleCurves;

        public BounceEffects(Rigidbody rigidbody, BounceData date, Vector3Curves scaleCurves)
        {
            _rigidbody = rigidbody;
            _date = date;
            _scaleCurves = scaleCurves;
        }
        public void ApplayUpwardsScaleTo(Transform scaledObject, Vector3 initialScale)
        {
            if (_rigidbody.velocity.y <= 0.0f) 
            {
                scaledObject.localScale = initialScale;            
                return;

            float percent = _rigidbody.velocity.y / _data.MaxHeight;

            Vector3 scale = new Vector3
            {
                x = _scaleCurves.XCurve.Evaluate(percent),
                y = _scaleCurves.YCurve.Evaluate(percent),
                z = _scaleCurves.ZCurve.Evaluate(percent)
            };
        }

    }
}
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

using System;
using UnityEngine;

namespace Assets.Scripts.Phyzics.Bounce
{
    [System.Serializable]
    public class BounceData
    {
        [SerializeField] private float _force;
        [SerializeField] private float _maxHeight;

       public float Force => _force;
        public float MaxHeight => _maxHeight;
    }
}
using Assets.Scripts.Phyzics;
using Assets.Scripts.Phyzics.Bounce;
using System;
using UnityEngine;
using Assets.Scripts.Structur;

namespace Assets.Scripts.Ball
{
    public class BallBounce : MonoBehaviour
    {
        [Header("Required components")]
        [SerializeField] private Rigidbody _rigibody;
        [SerializeField] private Transform _mesh;

        [Header("Settings"]
        [SerializeField] private BounceData _bounceData;
        [SerializeField] private Vector3Curves _scaleCurves;

        private Bounce _bounce;
        private BounceEffects _bounceEffects;

        private Vector3 _meshInitialScale;
        private void Start()
        {
            _bounce = new Bounce(_rigibody, _bounceData);
            _bounceEffects = new BounceEffects(_rigibody, _bounceData, _scaleCurves);

            _meshInitialScale = _mesh.localScale;
        }   

       private void FixedUpdate()
        {
            _bounce.ClampHeight();
            _bounceEffects.ApplayUpwardsScaleTo(_mesh, _meshInitialScale);
        }
        private void OnCollisionEnter(Collision other)
        {
            _bounce.BounceOff(Vector3.up);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Phyzics.Bounce
{
    public class Bounce
    {
        private readonly Rigidbody _rigidbody;
        private readonly BounceData _data;
      
        public Bounce(Rigidbody rigidbody, BounceData data)
        {
            _rigidbody = rigidbody;
            _data = data;            
        }

        public void BounceOff(Vector3 direction) => 
            _rigidbody.AddForce(direction * _data.Force, ForceMode.VelocityChange);
        public void ClampHeight() 
        {
            Vector3 velocity = _rigidbody.velocity;

            _rigidbody.velocity = velocity.y >= 0.0f
                ? Vector3.ClampMagnitude(velocity, _data.MaxHeight)
                : velocity;
        }

    }
}



