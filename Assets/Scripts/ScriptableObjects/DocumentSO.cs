using System.Collections;
using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewDocument", menuName = "Artistas/Documents/New Document")]
    public class DocumentSO : ScriptableObject
    {
        [Header("Data")]
        public Sprite icon;
        public string title;

        [Header("Prefabs")]
        public GameObject documentPrefab;
    }
}