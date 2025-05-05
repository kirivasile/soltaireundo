using UnityEngine;

namespace SolitaireUndo.UserInteraction
{
    /// <summary>
    /// Snaps card positions to the stacks.
    /// </summary>
    public class CardSnapper
    {
        private readonly RectTransform[] _snapPositions;

        public CardSnapper(RectTransform[] snapPositions)
        {
            _snapPositions = snapPositions;
        }

        public Vector3? TrySnapPosition(Vector3 position)
        {
            foreach (var possiblePosition in _snapPositions)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(possiblePosition, position))
                {
                    return possiblePosition.position;
                }
            }
            return null;
        }
    }
}