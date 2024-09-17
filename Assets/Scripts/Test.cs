using System;
using Input.Swipes;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private InputSwipePanel _swipePanel;

        private void OnEnable()
        {
            _swipePanel.Swiping += OnSwiping;
        }

        private void OnDisable()
        {
            _swipePanel.Swiping -= OnSwiping;   
        }

        private void OnSwiping(Swipe swipe)
        {
            transform.position += (Vector3)swipe.Delta;
        }
    }
    
}