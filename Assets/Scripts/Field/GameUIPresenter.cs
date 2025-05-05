using SolitaireUndo.UndoSystem;
using UnityEngine.UI;

namespace SolitaireUndo.Field
{
    // TODO Improvement: Add model and view classes.
    public class GameUIPresenter
    {
        private readonly UndoStack<CardMoveAction> _moveUndoStack;
        private readonly Button _undoButton;

        public GameUIPresenter(UndoStack<CardMoveAction> moveUndoStack, Button undoButton)
        {
            _moveUndoStack = moveUndoStack;
            moveUndoStack.OnUndoAvailableChanged += OnUndoAvailableChanged;

            _undoButton = undoButton;
            undoButton.interactable = false;
            undoButton.onClick.AddListener(OnUndoButtonClick);
        }

        private void OnUndoAvailableChanged(bool isAvailable) => _undoButton.interactable = isAvailable;

        private void OnUndoButtonClick() => _moveUndoStack.Undo();

        public void Dispose()
        {
            _undoButton.onClick.RemoveListener(OnUndoButtonClick);
            _moveUndoStack.OnUndoAvailableChanged -= OnUndoAvailableChanged;
        }
    }
}