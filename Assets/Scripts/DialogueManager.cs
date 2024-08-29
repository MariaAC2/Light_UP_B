using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Dialogue
{
    public bool wasShown;
    public List<string> text;
    public string hook;
    public Dialogue(List<string> _text, string _hook)
    {
        text = _text;
        hook = _hook;
        wasShown = false;
    }
}
public class DialogueManager : MonoBehaviour
{
    Dialogue[] gameDialogues;
    // Start is called before the first frame update
    void Start()
    {
        SaveGame.DeleteSaves();
        gameDialogues = SaveGame.LoadDialogues();
        if(gameDialogues == null) { 
            gameDialogues = new Dialogue[] { 
                new Dialogue(new List<string> { "Welcome to our game", "Hope you enjoy" }, "Start"),
                new Dialogue(new List<string> { "Welcome Back!", "Have fun" }, "StartAgain"),
                new Dialogue(new List<string> {"Welcome to the first room! You have to solve the circuit on the table"}, "Ec105_in"),
                new Dialogue(new List<string> {"Now press P to see the table clearer and play, and back to P to return"}, "Ec105_in2")
            };
            PlayDialogue("Start");
        }
        else
        {
            PlayDialogue("StartAgain", true);
        }

    }
    public void PlayDialogue(string hook, bool persistent = false)
    {
        for(int i=0;i<gameDialogues.Length; i++) 
        {
            if (gameDialogues[i].hook == hook)
            {
                if (gameDialogues[i].wasShown)
                {
                    return;
                }
                StartCoroutine(Dialogs.ShowDialog(gameDialogues[i].text));
                if (!persistent)
                {
                    gameDialogues[i].wasShown = true;
                }
                return;
            }
        }
    }
    private void OnApplicationQuit()
    {
        SaveGame.SaveDialogues(this.gameDialogues);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
