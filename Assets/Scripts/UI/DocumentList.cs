using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    public class DocumentList : MonoBehaviour
    {
        [field: Header("Documents")]
        [field: SerializeField] public List<DocumentSO> Documents { get; set; }

        [Header("Prefabs")]
        [SerializeField] private GameObject documentPrefab;

        public void SetDocumentsList()
        {
            Clear();

            foreach (DocumentSO document in Documents)
            {
                DocumentEntry documentEntry = Instantiate(documentPrefab, transform).GetComponent<DocumentEntry>();

                documentEntry.Initialize(document);
            }
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