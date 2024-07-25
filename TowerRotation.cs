using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Input
{
    public readonly struct Swipe
    {
        public Vector2 StartPosition { get; }
        public Vector2 EndPosition { get; }
        public Vector2 Delta { get; }
        public Swipe(Vector2 startPosition, Vector2 endPosition, Vector2 delta)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            Delta = delta;
        }

        public Vector2 NormalizedDelta => Delta.normalized;

    }
     internal class InputSwipePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
 {
     public event Action<Swipe> SwipeBegane;
     public event Action<Swipe> Swiping;
     public event Action<Swipe> SwipeEnded;
     private Vector2 _startPosition;
     public void OnBeginDrag(PointerEventData eventData)
     {
         _startPosition = eventData.position;
         Invoke(SwipeBegane, eventData);
     }

     public void OnDrag(PointerEventData eventData)
     {
         Invoke(Swiping, eventData);
     }

     public void OnEndDrag(PointerEventData eventData)
     {
         Invoke(SwipeEnded, eventData);
     }

     private void Invoke(Action<Swipe> action, PointerEventData eventData) =>
         action?.Invoke(CreateSwipeFrom(_startPosition, eventData));
     private Swipe CreateSwipeFrom(Vector2 startPosition, PointerEventData eventData) =>
         new Swipe(startPosition, endPosition: eventData.position, eventData.delta);
 }
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
           _towerRotation.Rotate(xAxis);

       }
   }
   internal class TowerRotation : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _rotationSpeed;
    [SerializeField][Min(0.0f)] private float _angularDrag;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnValidate() =>
        _rigidbody.angularDrag = _angularDrag;
    public void Rotate(float xAxis)
    {
        Vector3 torque = Vector3.up * xAxis * Time.deltaTime * _rotationSpeed * -1;
        
        _rigidbody.AddTorque(torque, ForceMode.Acceleration);
    }
}
}