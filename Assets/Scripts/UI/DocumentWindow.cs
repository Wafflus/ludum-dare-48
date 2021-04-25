using UnityEngine;

namespace Artistas
{
    public class DocumentWindow : MonoBehaviour
    {
        public void SetDocument(DocumentSO document)
        {
            Clear();

            Instantiate(document.documentPrefab, transform);
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
