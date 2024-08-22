using System.Collections.Generic;
using UnityEngine;

public class BoardObject : MonoBehaviour {
    public List<BoardObject> Inputs { get; set; }
    public List<BoardObject> Outputs { get; set; }
    public List<LineRenderer> Wires { get; set; }
}

public class InputButton : BoardObject {
    public bool Value { get; set; }
}