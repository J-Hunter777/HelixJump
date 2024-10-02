using UnityEngine;

namespace Ball
{
    public class BallParticles : MonoBehaviour
    {
        private const float SurfaceYOffset = 0.06f;
        [SerializeField] ParticleSystem _collisionPaticlesPrefab;
        [SerializeField] ParticleSystem _spotPaticlePreafab;
        [SerializeField] ParticleSystem _destroyParticlesPrefab;

        private ParticleSystem _collisionParticles;
        private void Start() => 
            _collisionParticles = Instantiate(_collisionPaticlesPrefab);

        private void OnCollisionEnter(Collision other)
        {
            EmitSpotParticles(other);
            EmitCollisionParticles(other);
        }

        public void EmitCollisionParticles(Collision other)
        {
            Vector3 collisionPoints = other.contacts[0].point;
            _collisionParticles.transform.position = collisionPoints;
            _collisionParticles.Play();
        }
        public void EmitSpotParticles(Collision collision)
        {
            Vector3 collisionPosition = collision.contacts[0].point + Vector3.up * SurfaceYOffset;
            Instantiate(_spotPaticlePreafab, collisionPosition, Quaternion.identity, collision.transform); ;
        }
        public void EmitDestroyParticles(Vector3 position) =>
            Instantiate(_destroyParticlesPrefab, position, Quaternion.identity, null);
    }
}
