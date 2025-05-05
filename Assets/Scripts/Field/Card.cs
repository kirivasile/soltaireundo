using UnityEngine;
using SolitaireUndo.UserInteraction;
using SolitaireUndo.UndoSystem;

namespace SolitaireUndo.Field
{
    public class Card : System.IDisposable
    {
        private readonly CardView _cardView;
        private readonly CardSnapper _cardSnapper;
        private readonly DragController _dragController;
        private readonly UndoStack<CardMoveAction> _moveUndoStack;
        private readonly RectTransform _viewTransform;

        public Card(CardView cardView, Sprite sprite, CardSnapper cardSnapper, UndoStack<CardMoveAction> moveUndoStack)
        {
            _cardView = cardView;
            _cardSnapper = cardSnapper;
            _moveUndoStack = moveUndoStack;

            cardView.Setup(sprite);
            var dragController = _dragController = cardView.gameObject.AddComponent<DragController>();
            var viewTransform =_viewTransform = cardView.transform as RectTransform;
            dragController.Setup(viewTransform);

            dragController.OnDragFinished += OnDragFinished;
        }

        private void OnDragFinished(in DragController.DragProcess dragProcess)
        {
            var maybeSnappedPosition = _cardSnapper.TrySnapPosition(_cardView.Position);
            if (maybeSnappedPosition.HasValue)
            {
                _cardView.Position = maybeSnappedPosition.Value;
                _moveUndoStack.Record(new CardMoveAction(_viewTransform, dragProcess.StartPosition, maybeSnappedPosition.Value));
            }
            else
            {
                _cardView.Position = dragProcess.StartPosition;
            }
        }

        public void Dispose()
        {
            _dragController.OnDragFinished -= OnDragFinished;
            Object.Destroy(_cardView.gameObject);
        }
    }
}