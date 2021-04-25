using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artistas
{
    public class DocumentEntry : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI documentName;
        [SerializeField] private Button button;

        [Header("Events")]
        [SerializeField] private DocumentEvent documentEvent;

        private DocumentSO currentDocument;

        public void Initialize(DocumentSO document)
        {
            currentDocument = document;

            icon.sprite = document.icon;
            documentName.text = document.title;

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            documentEvent.Raise(currentDocument);
        }
    }
}