using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    // UI
    public GameObject conversationUI;
    public Text NPCLineUI;
    public Text responseLineUI;

    // Data
    public ConversationData[] conversations;
    public int currentConversation = 0;

    // Start conversation Button
    public GameObject startConversationUI;

    // Camera
    CameraController cameraController;

    void Start()
    {
        // Reset all conversations
        for (int i = 0; i < conversations.Length; i++)
            ResetConversation(i);

        startConversationUI.SetActive(false);
        conversationUI.SetActive(false);

        cameraController = FindObjectOfType<CameraController>();
    }

    void ResetConversation(int index)
    {
        conversations[index].completed = false;
        conversations[index].step = 0;
    }

	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.F) && startConversationUI.activeSelf && !conversationUI.activeSelf)
        {
            SetStartConversationUI(false);
            DisplayConversation();
        }
    }


	public void DisplayConversation() 
    {
        Cursor.visible = true;
        cameraController.enabled = false;

        if(!conversationUI.activeSelf)
            conversationUI.SetActive(true);

        if(!conversations[currentConversation].completed)
        {
            int step = conversations[currentConversation].step;
            NPCLineUI.text = conversations[currentConversation].NPCLine[step];
            responseLineUI.text = conversations[currentConversation].responseLine[step];
            conversations[currentConversation].StepReady();
        }
        else
        {
            HideConversation();
            ResetConversation(currentConversation);
        }
    }

    public void HideConversation()
    {
        conversationUI.SetActive(false);
        Cursor.visible = false;
        cameraController.enabled = true;
    }

    public void SetStartConversationUI(bool state)
    {
        startConversationUI.SetActive(state);
    }
}
