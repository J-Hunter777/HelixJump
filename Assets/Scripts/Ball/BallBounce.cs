using Phyzics.Bounce;
using Structur;
using UnityEngine;

namespace Ball
{
    public class BallBounce : MonoBehaviour
    {
        [Header("Required components")]
        [SerializeField] private Rigidbody _rigibody;
        [SerializeField] private Transform _mesh;

        [Header("Settings")]
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
        public void BounceOff(Vector3 direction)
        {
            _bounce.BounceOff(direction);
        }

    }
}
