using SolitaireUndo.UserInteraction;
using UnityEngine;
using UnityEngine.UI;

namespace SolitaireUndo.Field
{
    [RequireComponent(typeof(Image))]
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void Setup(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}