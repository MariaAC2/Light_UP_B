using UnityEngine;

public class AndGate : BoardObject {
    public void Start() {
        Inputs.Capacity = 2;
    }

    public override void onChange() { 
        if (Inputs.Count == 2) {
            // Evaluează stările inputurilor
            bool input1Value = Inputs[0].Value;
            bool input2Value = Inputs[1].Value;

            // Calculează outputul logic pentru poarta AND
            Value = input1Value && input2Value;

            // Notifică outputurile conectate că valoarea s-a schimbat
            NotifyOutputs();

            // Schimbă culoarea firului de output
            ChangeWireColor(Value);
        }
    }

    private void NotifyOutputs() {
        foreach (var output in Outputs) {
            output.onChange(); // Apelează onChange pentru fiecare output
        }
    }

    private void ChangeWireColor(bool state) {
        foreach (var wire in Wires) {
            // Schimbă culoarea firului în verde dacă outputul este TRUE, sau albastru dacă este FALSE
            wire.startColor = state ? Color.green : Color.blue;
            wire.endColor = state ? Color.green : Color.blue;
        }
    }
}