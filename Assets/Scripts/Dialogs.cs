using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Dialogs
{
    private static readonly GameObject dialogBox;
    private static readonly GameObject dialogText;

    public enum DialogState
    {
        HIDDEN, RUNNING, FINISHED
    };
    static public DialogState State { get; private set; }

    static Dialogs()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialogText = GameObject.Find("DialogText");
    }

    public static IEnumerator ShowDialog(List<string> dialogs)
    {
        // fade dialog box in
        dialogBox.SetActive(true);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            dialogBox.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.05f);
        }

        // add text character by character
        foreach (string dialog in dialogs)
        {
            dialogText.GetComponent<TMP_Text>().text = "";
            for (int i = 0; i < dialog.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogText.GetComponent<TMP_Text>().text = dialog;
                    break;
                }
                dialogText.GetComponent<TMP_Text>().text += dialog[i];
                yield return new WaitForSeconds(1f / dialog.Length);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
        // remove text
        dialogText.GetComponent<TMP_Text>().text = "";

        // fade dialog box out
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            dialogBox.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.05f);
        }
        dialogBox.SetActive(false);
    }
    public static IEnumerator ShowDialog(string dialog)
    {
        return ShowDialog(new List<string> { dialog });
    }
}
