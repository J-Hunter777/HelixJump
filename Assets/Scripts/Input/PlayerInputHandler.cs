using Assets.Scripts.Tower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input.Swipes;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
       [Header("Input")]
        [SerializeField] private InputSwipePanel _swipePanel;
       [Header("Tower")]
        [SerializeField] private TowerRotation _towerRotation;

        private void OnEnable() => 
            _swipePanel.Swiping += RotateTower;
        
        private void OnDisable() => 
            _swipePanel.Swiping -= RotateTower;
        private void RotateTower(Swipe swipe)
        {
            float xAxis = swipe.Delta.x;
            _towerRotation.AddRotation(xAxis);

        }
    }
}
