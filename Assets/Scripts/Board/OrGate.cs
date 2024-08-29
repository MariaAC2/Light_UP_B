using UnityEngine;

public class OrGate : BoardObject {
    public void Start() {
        Inputs.Capacity = 2;
    }

    public override void onChange() {
        if (Inputs.Count == 2) {
            bool input1Value = Inputs[0].Value;
            bool input2Value = Inputs[1].Value;

            // Logica pentru poarta OR
            Value = input1Value || input2Value;

            NotifyOutputs();
            ChangeWireColor(Value);
        }
    }

    private void NotifyOutputs() {
        foreach (var output in Outputs) {
            output.onChange();
        }
    }

    private void ChangeWireColor(bool state) {
        foreach (var wire in Wires) {
            wire.startColor = state ? Color.green : Color.blue;
            wire.endColor = state ? Color.green : Color.blue;
        }
    }
}