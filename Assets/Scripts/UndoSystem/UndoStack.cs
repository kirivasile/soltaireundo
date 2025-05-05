using System;
using System.Collections.Generic;

namespace SolitaireUndo.UndoSystem
{
    public class UndoStack<TAction> where TAction : IUndoAction
    {
        private readonly Stack<TAction> _undoStack = new Stack<TAction>();

        public event Action<bool> OnUndoAvailableChanged;

        public void Record(TAction action)
        {
            _undoStack.Push(action);
            OnUndoAvailableChanged?.Invoke(true);
        }

        private bool CanUndo() => _undoStack.Count > 0;

        public void Undo()
        {
            if (CanUndo())
            {
                var action = _undoStack.Pop();
                action.Undo();
                OnUndoAvailableChanged?.Invoke(CanUndo());
            }
        }
    }
}