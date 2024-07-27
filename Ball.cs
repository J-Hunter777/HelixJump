using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Assets.Scripts.Tower
{
    internal class TowerRotation : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotationSpeed;
        private Quaternion _newRotationAngle;
        
        private void Update()
        {
            transform.rotation = CalculateRotation(_rotationSpeed * Time.deltaTime);
        }
        private Quaternion CalculateRotation(float rotationSpeed) =>
            Quaternion.Slerp(transform.rotation, _newRotationAngle, rotationSpeed);
        public void AddRotation(float xAxis)
        {
            Vector3 newEulerRotationAngle = transform.eulerAngles + Vector3.down * xAxis;
            _newRotationAngle = Quaternion.Euler(newEulerRotationAngle);

        }
    }
}
//Add ball bouncy
//Create Ball Collision Effect
