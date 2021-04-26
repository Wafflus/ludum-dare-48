using System;
using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    [Serializable]
    public class ChoiceData
    {
        [Header("Data")]
        public string text;
        public DialogueSO nextDialogue;

        [Header("Events")]
        public UnityEvent onChosen;

        [Header("Conditions")]
        public bool chosen;
    }
}