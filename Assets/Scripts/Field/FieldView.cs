using UnityEngine;

namespace SolitaireUndo.Field
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _stacks;
        [SerializeField] private Transform _cardsParent;

        public RectTransform[] StackTransforms => _stacks;
        public Transform CardsParent => _cardsParent;
    }
}
