using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artist : NPC, NPCDialogue
{
    [SerializeField] private DialogueText dialtext;
    [SerializeField] private Dialogue dialCtrl;

    public override void Interact()
    {
        Talk(dialtext);
    }

    public void Talk(DialogueText dialtext)
    {
        dialCtrl.NextLine(dialtext);
    }
}