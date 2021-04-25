using TMPro;
using UnityEngine;

namespace Artistas
{
    public class Dialogue : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI sender;
        [SerializeField] private TextMeshProUGUI dialogue;

        public void Initialize(DialogueSO dialogueSO)
        {
            sender.text = dialogueSO.senderName;
            dialogue.text = dialogueSO.text;
        }
    }
}