using SolitaireUndo.UndoSystem;
using UnityEngine;

namespace SolitaireUndo.Field
{
    public readonly struct CardMoveAction : IUndoAction
    {
        public readonly RectTransform CardTransform;
        public readonly Vector3 OriginalPosition;
        public readonly Vector3 NewPosition;

        public CardMoveAction(RectTransform cardTransform, Vector3 originalPosition, Vector3 newPosition)
        {
            CardTransform = cardTransform;
            OriginalPosition = originalPosition;
            NewPosition = newPosition;
        }

        public void Undo()
        {
            CardTransform.position = OriginalPosition;
            CardTransform.SetAsLastSibling();
        }
    }
}