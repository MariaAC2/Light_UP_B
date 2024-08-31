using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Importă spațiul de nume pentru UI

public class Ec105LevelManager : MonoBehaviour
{
    public BoardObject[] winConditions;
    public Light levelLight;  // Referință la lumina din scenă
    public Text levelCompleteText;  // Referință la textul UI pentru dialog
    bool levelFinished = false;

    // Update is called once per frame
    void Update()
    {
        bool won = true;
        foreach (BoardObject winCondition in winConditions)
        {
            if (!winCondition.Value)
            {
                won = false;
                break;
            }
        }

        if (won && !levelFinished)
        {
            // Nivel completat corect
            Debug.Log("Player has completed ec105");
            levelFinished = true;

            // Aprinde lumina
            levelLight.enabled = true;

        
        }
    }
}
