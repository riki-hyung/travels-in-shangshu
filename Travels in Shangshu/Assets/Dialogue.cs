using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10f;
    
    private Queue<string> lines = new Queue<string>();

    private bool talkEnded;
    private string nextText;
    private Coroutine dialogueCoroutine;
    private bool isTalking;
    private const string HTML_ALPHA = "<color=#FFFFFFFF>";
    private const float MAX_TYPE_TIME = 0.1f;

    public void NextLine(DialogueText dialtext)
    {
        if(lines.Count == 0)
        {
            if(!talkEnded)
            {
                StartConverstaion(dialtext);
            }
            else if(talkEnded && !isTalking)
            {
                EndConverstation();
                return;
            }
        }

        if(!isTalking)
        {
            nextText = lines.Dequeue();
            dialogueCoroutine = StartCoroutine(TypeDialogueText(nextText));
        }
        else
        {
            FinishTalking();
        }
        
        if(lines.Count == 0)
        {
            talkEnded = true;
        }
    }

    private void StartConverstaion(DialogueText dialtext)
    {
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        
        NPCNameText.text = dialtext.speakerName;

        for(int i = 0; i < dialtext.paragraphs.Length; i++)
        {
            lines.Enqueue(dialtext.paragraphs[i]);
        }
    }

    private void EndConverstation()
    {
        lines.Clear();
        talkEnded = false;

        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string nextText)
    {
        isTalking = true;
        NPCDialogueText.text = "";
        string originalText = nextText;
        string displayedText = "";
        int alphaIndex = 0;

        foreach(char c in nextText.ToCharArray())
        {
            alphaIndex++;
            NPCDialogueText.text = originalText;

            displayedText = NPCDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            NPCDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }
        
        isTalking = false;
    }

    private void FinishTalking()
    {
        StopCoroutine(dialogueCoroutine);
        NPCDialogueText.text = nextText;
        isTalking = false;
    }
}
