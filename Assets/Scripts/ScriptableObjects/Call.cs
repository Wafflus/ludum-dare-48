using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewCall", menuName = "Artistas/Call/New Call")]
    public class Call : ScriptableObject
    {
        [Header("Caller Info")]
        public string callerName;
        public string callerNumber;

        [Header("Receiver Info")]
        public string receiverName;
        public string receiverNumber;

        [Header("Dialogues")]
        public DialogueSO startingDialogue;
    }
}