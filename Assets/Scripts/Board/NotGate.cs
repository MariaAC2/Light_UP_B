using UnityEngine;

public class NotGate : BoardObject {
    public void Start() {
        Inputs.Capacity = 1;
    }

    public override void onChange() {
        if (Inputs.Count == 1) {
            bool input1Value = Inputs[0].Value;

            // Logica pentru poarta NOT
            Value = !input1Value;

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