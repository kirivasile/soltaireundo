using UnityEngine;
using Random = System.Random;

namespace SolitaireUndo.Field
{
    /// <summary>
    /// Generates a random sprite for a card on the field.
    /// </summary>
    public class CardGenerator
    {
        private readonly FieldConfig _fieldConfig;
        private readonly Random _random;

        public CardGenerator(FieldConfig fieldConfig)
        {
            _fieldConfig = fieldConfig;
            _random = new Random();
        }

        public Sprite NextCard() => 
            _fieldConfig.CardSprites[_random.Next(_fieldConfig.CardSprites.Length)];
    }
}