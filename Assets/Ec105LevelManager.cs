using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ec105LevelManager : MonoBehaviour
{
    public BoardObject[] winConditions;
    bool levelFinished = false;

    // Update is called once per frame
    void Update()
    {
        bool won = true;
        foreach (BoardObject winCondition in winConditions)
        {
            if(!winCondition.Value)
            {
                won = false;
            }
        }
        if (won && !levelFinished)
        {
            //aici cod pt cand e completat nivelul
            Debug.Log("Player has completed ec105");
            levelFinished = won;
        }
    }
}
