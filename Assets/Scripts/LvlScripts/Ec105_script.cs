using UnityEngine;
using UnityEngine.UI; // Importă spațiul de nume pentru UI

public class DialogTrigger : MonoBehaviour
{
    public Text dialogText; // Asociază UI-ul care conține textul dialogului în Inspector
    public string message = "Welcome to the first room! You have to solve the circuit on the table"; // Textul pe care vrei să-l afișezi
    public DialogueManager manager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShowDialogue");
            manager.PlayDialogue("Ec105_in");
        }
    }

}

