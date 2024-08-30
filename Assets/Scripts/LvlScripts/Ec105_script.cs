﻿using UnityEngine;
using UnityEngine.UI; // Importă spațiul de nume pentru UI

public class DialogTrigger : MonoBehaviour
{
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

