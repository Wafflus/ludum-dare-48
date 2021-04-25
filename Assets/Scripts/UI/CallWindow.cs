using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Artistas
{
    public class CallWindow : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private ScrollRect scrollRect;

        [Header("Prefabs")]
        [SerializeField] private GameObject dialoguePrefab;
        [SerializeField] private GameObject choicePrefab;

        public void SetCallDialogues(Call call)
        {
            if (call.startingDialogue == null)
            {
                return;
            }

            Clear();

            DialogueSO dialogue = call.startingDialogue;

            while (dialogue != null && dialogue.sent)
            {
                Dialogue dialogueGameObject = CreateDialogue(dialogue);

                List<ChoiceData> choices = dialogue.choices;

                if (choices.Count == 0)
                {
                    dialogue = dialogue.nextDialogue;
                }

                foreach (ChoiceData choice in choices)
                {
                    CreateChoice(dialogueGameObject, choice, true);

                    if (choice.chosen)
                    {
                        dialogue = choice.nextDialogue;
                    }
                }
            }

            if (dialogue != null)
            {
                StartCoroutine(SetNext(dialogue));
            }

            StartCoroutine(ForceScrollDown());
        }

        private void CreateChoice(Dialogue dialogueGameObject, ChoiceData choice, bool disableChoice)
        {
            Choice choiceGameObject = Instantiate(choicePrefab, dialogueGameObject.gameObject.transform).GetComponent<Choice>();

            choiceGameObject.Initialize(choice, disableChoice);
        }

        public void Next(DialogueSO dialogue)
        {
            if (dialogue == null)
            {
                return;
            }

            if (!dialogue.Enabled)
            {
                return;
            }

            Dialogue dialogueGameObject = CreateDialogue(dialogue);

            List<ChoiceData> choices = dialogue.choices;

            foreach (ChoiceData choice in choices)
            {
                CreateChoice(dialogueGameObject, choice, false);
            }

            dialogue.sent = true;

            if (choices.Count == 0)
            {
                dialogue = dialogue.nextDialogue;

                StartCoroutine(SetNext(dialogue));
            }

            StartCoroutine(ForceScrollDown());
        }

        public IEnumerator SetNext(DialogueSO dialogue)
        {
            yield return new WaitForSeconds(5f);

            Next(dialogue);
        }

        private Dialogue CreateDialogue(DialogueSO dialogue)
        {
            Dialogue dialogueGameObject = Instantiate(dialoguePrefab, transform).GetComponent<Dialogue>();

            dialogueGameObject.Initialize(dialogue);

            return dialogueGameObject;
        }

        private IEnumerator ForceScrollDown()
        {
            yield return new WaitForEndOfFrame();

            scrollRect.verticalNormalizedPosition = 0f;
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