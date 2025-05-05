using SolitaireUndo.UndoSystem;
using SolitaireUndo.UserInteraction;
using UnityEngine.UI;

namespace SolitaireUndo.Field
{
    /// <summary>
    /// Main controller for the game. Initializes all of the controllers that are needed to run the game.
    /// </summary>
    public class GameController : System.IDisposable
    {
        private readonly FieldController _fieldController;
        private readonly GameUIPresenter _gameUIPresenter;

        public GameController(FieldView fieldView, FieldConfig fieldConfig, Button undoButton)
        {
            // TODO Optimization: Use DI container to manage dependencies.
            var cardGenerator = new CardGenerator(fieldConfig);
            var cardSnapper = new CardSnapper(fieldView.StackTransforms);
            var moveUndoStack = new UndoStack<CardMoveAction>();
            
            _fieldController = new FieldController(cardGenerator, cardSnapper, moveUndoStack, fieldView, fieldConfig);

            _gameUIPresenter = new GameUIPresenter(moveUndoStack, undoButton);

            StartGame();
        }

        private void StartGame()
        {
            _fieldController.InitField();
        }

        public void Dispose()
        {
            _gameUIPresenter.Dispose();
        }
    }
}