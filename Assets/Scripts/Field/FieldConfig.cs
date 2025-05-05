using UnityEngine;

namespace SolitaireUndo.Field
{
    [CreateAssetMenu(fileName = "FieldConfig", menuName = "ScriptableObjects/FieldConfig", order = 1)]
    public class FieldConfig : ScriptableObject
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private Sprite[] _cardSprites;
        [SerializeField] private int _numCardsPerStack;

        public Sprite[] CardSprites => _cardSprites;
        public int NumCardsPerStack => _numCardsPerStack;
        public CardView CardPrefab => _cardPrefab;
    }
}