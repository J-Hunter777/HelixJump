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
}