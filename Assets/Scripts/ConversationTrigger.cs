using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public int conversationNumber; // Define this conversation
    ConversationController conversationController;

    private void Awake() => conversationController = FindObjectOfType<ConversationController>();

	private void OnTriggerEnter(Collider other)
	{
		conversationController.currentConversation = conversationNumber;
		conversationController.SetStartConversationUI(true);
	}

	private void OnTriggerExit(Collider other)
	{
		conversationController.SetStartConversationUI(false);
	}
}
