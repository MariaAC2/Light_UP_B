using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardObject : MonoBehaviour {
    public List<BoardObject> Inputs { get; set; } = new(2);
    public List<BoardObject> Outputs { get; set; } = new(1);
    public List<LineRenderer> Wires { get; set; } = new(1);

    public bool Value { get; set; }
}