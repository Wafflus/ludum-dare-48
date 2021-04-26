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
            Clear();

            if (call.startingDialogue == null)
            {
                return;
            }

            DialogueSO dialogue = call.startingDialogue;
            DialogueSO currentDialogue = dialogue;

            bool optionChosen = false;
            bool first = true;

            while (dialogue != null && dialogue.sent)
            {
                currentDialogue = dialogue;
                first = false;

                optionChosen = false;

                Dialogue dialogueGameObject = CreateDialogue(dialogue);

                List<ChoiceData> choices = dialogue.choices;

                if (choices.Count == 0)
                {
                    dialogue = dialogue.nextDialogue;
                }

                List<Choice> instantiatedChoices = new List<Choice>();

                foreach (ChoiceData choice in choices)
                {
                    Choice createdChoice = CreateChoice(dialogueGameObject, choice, true);

                    instantiatedChoices.Add(createdChoice);

                    if (choice.chosen)
                    {
                        dialogue = choice.nextDialogue;

                        optionChosen = true;
                    }
                }

                if (choices.Count > 0 && !optionChosen)
                {
                    foreach (Choice choice in instantiatedChoices)
                    {
                        choice.UpdateButtonInteractable(true);
                    }

                    break;
                }
            }

            if (dialogue != null)
            {
                if (currentDialogue.choices.Count == 0 || optionChosen || first)
                {
                    StartCoroutine(SetNext(dialogue));
                }
            }

            StartCoroutine(ForceScrollDown());
        }

        private Choice CreateChoice(Dialogue dialogueGameObject, ChoiceData choice, bool disableChoice)
        {
            Choice choiceGameObject = Instantiate(choicePrefab, dialogueGameObject.gameObject.transform).GetComponent<Choice>();

            choiceGameObject.Initialize(choice, disableChoice);

            return choiceGameObject;
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

            dialogue.action.Invoke();

            if (choices.Count == 0)
            {
                dialogue = dialogue.nextDialogue;

                StartCoroutine(SetNext(dialogue));
            }

            StartCoroutine(ForceScrollDown());
        }

        public void StopCall()
        {
            StopAllCoroutines();
        }

        public IEnumerator SetNext(DialogueSO dialogue)
        {
            yield return new WaitForSeconds(Random.Range(3, 5f));

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