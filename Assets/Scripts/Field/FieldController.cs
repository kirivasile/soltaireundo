using UnityEngine;
using System.Collections.Generic;
using SolitaireUndo.UserInteraction;
using SolitaireUndo.UndoSystem;

namespace SolitaireUndo.Field
{
    /// <summary>
    /// Responsible for creating and disposing of cards in the field.
    /// </summary>
    public class FieldController
    {
        private readonly CardGenerator _cardGenerator;
        private readonly CardSnapper _cardSnapper;
        private readonly UndoStack<CardMoveAction> _moveUndoStack;
        private readonly FieldView _fieldView;
        private readonly FieldConfig _fieldConfig;
        private readonly List<Card> _cards;

        public FieldController(CardGenerator cardGenerator, CardSnapper cardSnapper, UndoStack<CardMoveAction> moveUndoStack, FieldView fieldView, FieldConfig fieldConfig)
        {
            _cardGenerator = cardGenerator;
            _cardSnapper = cardSnapper;
            _moveUndoStack = moveUndoStack;
            _fieldView = fieldView;
            _fieldConfig = fieldConfig;
            _cards = new ();
        }

        public void InitField()
        {
            // TODO Optimization: reuse existing views.
            ClearCards();
            foreach (var stack in _fieldView.StackTransforms)
            {
                for (int i = 0; i < _fieldConfig.NumCardsPerStack; i++)
                {
                    var cardSprite = _cardGenerator.NextCard();
                    var cardView = Object.Instantiate(_fieldConfig.CardPrefab, stack.position, Quaternion.identity, _fieldView.CardsParent);
                    var card = new Card(cardView, cardSprite, _cardSnapper, _moveUndoStack);
                    _cards.Add(card);
                }
            }
        }

        private void ClearCards()
        {
            foreach (var card in _cards)
            {
                card.Dispose();
            }
            _cards.Clear();
        }
    }
}