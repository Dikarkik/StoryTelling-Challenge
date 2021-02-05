using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SendResponseButton : MonoBehaviour, IPointerDownHandler
{
    ConversationController conversationController;

	private void Awake() => conversationController = FindObjectOfType<ConversationController>();

	public void OnPointerDown(PointerEventData eventData)
    {
		conversationController.DisplayConversation();
    }
}
