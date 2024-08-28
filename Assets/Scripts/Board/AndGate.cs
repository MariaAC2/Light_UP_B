public class AndGate : BoardObject {
    public override bool Value {
        get => Inputs[0].Value && Inputs[1].Value;
    }
}