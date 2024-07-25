using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Input
{
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
        private Swipe CreateSwipeFrom (Vector2 startPosition, PointerEventData eventData) =>
            new Swipe(startPosition, endPosition: eventData.position, eventData.delta);
}
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
}