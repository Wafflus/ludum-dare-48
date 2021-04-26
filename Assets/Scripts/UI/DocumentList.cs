using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    public class DocumentList : MonoBehaviour
    {
        [Header("Documents")]
        [SerializeField] private List<DocumentSO> documents;

        [Header("Prefabs")]
        [SerializeField] private GameObject documentPrefab;

        public void SetDocumentsList()
        {
            Clear();

            for (int i = documents.Count - 1; i >= 0; --i)
            {
                DocumentEntry documentEntry = Instantiate(documentPrefab, transform).GetComponent<DocumentEntry>();

                documentEntry.Initialize(documents[i]);
            }
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void AddToList(DocumentSO document)
        {
            documents.Add(document);
        }
    }
}