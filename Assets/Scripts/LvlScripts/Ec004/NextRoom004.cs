using UnityEngine;
using UnityEngine.UI; // Importă spațiul de nume pentru UI

public class DialogTrigger004_in : MonoBehaviour
{
    public DialogueManager manager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShowDialogueEC001");
            manager.PlayDialogue("nextEc004");
        }
    }

}
