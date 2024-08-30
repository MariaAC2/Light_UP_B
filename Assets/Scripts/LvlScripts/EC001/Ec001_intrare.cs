using UnityEngine;
using UnityEngine.UI; // Import? spa?iul de nume pentru UI

public class DialogTrigger001_in : MonoBehaviour
{
    public DialogueManager manager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShowDialogueEC001");
            manager.PlayDialogue("enterEc001");
        }
    }

}
