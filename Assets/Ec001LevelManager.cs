using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ec001LevelManager : MonoBehaviour
{
    public BoardObject[] winConditions;
    public Light levelLight;  // Referință la lumina din scenă
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
            Debug.Log("Player has completed ec001");
            levelFinished = true;

            // Aprinde lumina
            levelLight.enabled = true;
        }
    }
}
