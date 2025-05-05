using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireUndo.UserInteraction
{
    /// <summary>
    /// Implementation of drag-and-drop functionality for cards.
    /// </summary>
    public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private event Action<PointerEventData> _onBeginDrag;
        private event Action<PointerEventData> _onDrag;
        private event Action<PointerEventData> _onEndDrag;
        
        public delegate void OnDragFinishedDelegate(in DragProcess dragProcess);
        public event OnDragFinishedDelegate OnDragFinished;

        private RectTransform _dragTransform;
        private DragProcess? _currentDragProcess;

        public void Setup(RectTransform dragTransform)
        {
            _dragTransform = dragTransform;

            _onBeginDrag += OnBeginDrag;
            _onDrag += OnDrag;
            _onEndDrag += OnEndDrag;
        }

        private void OnDestroy()
        {
            _onBeginDrag -= OnBeginDrag;
            _onDrag -= OnDrag;
            _onEndDrag -= OnEndDrag;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) => _onBeginDrag?.Invoke(eventData);
        void IDragHandler.OnDrag(PointerEventData eventData) => _onDrag?.Invoke(eventData);
        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => _onEndDrag?.Invoke(eventData);

        private void OnBeginDrag(PointerEventData eventData)
        {
            _currentDragProcess =  new DragProcess(_dragTransform.position);
            _dragTransform.SetAsLastSibling();
        }

        private void OnDrag(PointerEventData eventData)
        {
            _dragTransform.position = Input.mousePosition;
        }

        private void OnEndDrag(PointerEventData eventData)
        {
            if (!_currentDragProcess.HasValue)
            {
                Debug.LogError("Drag process is not initialized.");
                return;
            }

            OnDragFinished?.Invoke(_currentDragProcess.Value);
        }

        public readonly struct DragProcess
        {
            public readonly Vector3 StartPosition;

            public DragProcess(Vector3 startPosition)
            {
                StartPosition = startPosition;
            }
        }
    }
}