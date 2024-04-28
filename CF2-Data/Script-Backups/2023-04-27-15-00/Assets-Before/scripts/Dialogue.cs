using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class Dialogue : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessage;
    Actor[] currentActors;
    int activeMassage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] message, Actor[] actors)
    {
        currentMessage = message;
        currentActors = actors;
        activeMassage = 0;
        isActive = true;

        Debug.Log("started conversation! loaded message" + message.Length);
        displayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); ;
    }
    void displayMessage()
    {
        Message messageToDiaplay = currentMessage[activeMassage];
        messageText.text = messageToDiaplay.message;

        Actor actorToDisplay = currentActors[messageToDiaplay.ActorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }
    
    public void NextMessage()
    {
        activeMassage++;
        if (activeMassage < currentMessage.Length)
        {
            displayMessage();
        }
        else
        {
            Debug.Log("Conversation End!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }

    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);

    }
    // Start is called before the first frame update
    void Start()
    {
       backgroundBox.transform.localScale = Vector3.zero;
        
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && isActive == true)
        {
            NextMessage();
        }
    }






}
