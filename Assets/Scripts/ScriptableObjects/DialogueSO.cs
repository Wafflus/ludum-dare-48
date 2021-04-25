using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Artistas/Dialogue/New Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        [Header("Data")]
        public string senderName;
        [TextArea] public string text;
        public DialogueSO nextDialogue;

        [Header("Events")]
        public UnityEvent action;

        [Header("Choices")]
        public List<ChoiceData> choices;

        [Header("Conditions")]
        public bool sent;
        [field: SerializeField] public bool Enabled { get; set; }
    }
}