using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class DialogueManager
    {
        private StateManager stateManager;
        private DialogueWindow dialogueWindow;
        public DialogueManager(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.dialogueWindow = GameObject.FindObjectOfType<DialogueWindow>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            if (stateManager.TryState(GameState.Cutscene))
            dialogueWindow.StartCoroutine(Co_StartDialogue(dialogue));

        }
        private IEnumerator Co_StartDialogue(Dialogue dialogue)
        {
            dialogueWindow.Open(dialogue);

            while (dialogueWindow.IsOpen)
                yield return null;

            EndDialogue();
        }

        public void AdvanceDialogue()
        {
            if (dialogueWindow.IsAnimating)
                return;

            dialogueWindow.GoToNextLine();
        }

        private void EndDialogue() => stateManager.RestorePreviousState();
    }
}
