using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dialogue_Trigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    
    public void StartDialogue()
    {
        FindObjectOfType<Dialogue>().OpenDialogue(messages, actors);
    }

}

[System.Serializable]
public class Message
{
    public int ActorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;

}
