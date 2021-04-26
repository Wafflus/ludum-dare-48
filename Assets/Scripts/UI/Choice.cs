using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artistas
{
    public class Choice : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI choice;
        [SerializeField] private Button button;

        [Header("Events")]
        [SerializeField] private DialogueEvent dialogueEvent;

        private ChoiceData currentChoice;

        public void Initialize(ChoiceData choiceData, bool disableButton)
        {
            currentChoice = choiceData;

            choice.text = choiceData.text;

            if (choiceData.chosen)
            {
                UpdateChoiceColor();
            }

            UpdateButtonInteractable(!disableButton);

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            dialogueEvent.Raise(currentChoice.nextDialogue);

            currentChoice.chosen = true;

            currentChoice.onChosen.Invoke();

            UpdateChoiceColor();
        }

        private void UpdateChoiceColor()
        {
            choice.color = Color.green;
        }

        public void UpdateButtonInteractable(bool interactable)
        {
            button.interactable = interactable;
        }
    }
}