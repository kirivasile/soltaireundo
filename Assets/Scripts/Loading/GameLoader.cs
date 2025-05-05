using UnityEngine;
using SolitaireUndo.Field;
using UnityEngine.UI;

namespace SolitaireUndo.Loading
{
    /// <summary>
    /// Loads the game and have all links to the configs and views.
    /// </summary>
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private FieldConfig _fieldConfig;
        [SerializeField] private FieldView _fieldView;
        [SerializeField] private Button _undoButton;

        private GameController _gameController;

        private void Start()
        {
            _gameController = new GameController(_fieldView, _fieldConfig, _undoButton);
        }
            
        private void OnDestroy()
        {
            _gameController?.Dispose();
        }
    }
}