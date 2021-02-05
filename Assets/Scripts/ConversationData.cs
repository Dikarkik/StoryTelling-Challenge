using UnityEngine;

[CreateAssetMenu(fileName = "ConversationData", menuName = "ScriptableObjects/ConversationData", order = 1)]
public class ConversationData : ScriptableObject
{
    // control
    public bool completed = false;
    public int step = 0;

    // data
    public string[] NPCLine;
    public string[] responseLine;

    public void StepReady()
    {
        step++;

        if(step == NPCLine.Length)
        {
            completed = true;
        }
    }
}
