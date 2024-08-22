using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameBoard : MonoBehaviour
{
    [Serializable]
    public struct Connection {
        public int outputGateIndex;
        public int inputGateIndex;
        public int inputIndex;
        public readonly void Deconstruct(out int outputGateIndex, out int inputGateIndex, out int inputIndex) {
            outputGateIndex = this.outputGateIndex;
            inputGateIndex = this.inputGateIndex;
            inputIndex = this.inputIndex;
        }
    };

    private Transform inputsContainer = null;
    private Transform gatesContainer = null;
    private Transform wiresContainer = null;
    private Transform outputsContainer = null;

    [SerializeField] private List<Connection> connections = new();
    private List<InputButton> inputs = null;

    // Start is called before the first frame update
    void Start()
    {
        SetupHierarchy();
        SetupWires();
        SetupGates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.IsPlaying(gameObject)) {
            SetupHierarchy();
            SetupWires();
        }
    }

    void SetupHierarchy()
    {
        inputsContainer = transform.Find("Inputs");
        inputsContainer = inputsContainer ? inputsContainer : new GameObject("Inputs").transform;
        gatesContainer = transform.Find("Gates");
        gatesContainer = gatesContainer ? gatesContainer : new GameObject("Gates").transform;
        wiresContainer = transform.Find("Wires");
        wiresContainer = wiresContainer ? wiresContainer : new GameObject("Wires").transform;
        outputsContainer = transform.Find("Outputs");
        outputsContainer = outputsContainer ? outputsContainer : new GameObject("Outputs").transform;

        inputsContainer.position = gatesContainer.position = 
        wiresContainer.position = outputsContainer.position = transform.position;
        inputsContainer.SetParent(transform);
        gatesContainer.SetParent(transform);
        wiresContainer.SetParent(transform);
        outputsContainer.SetParent(transform);
    }

    void SetupGates()
    {
        inputs = new List<InputButton>(inputsContainer.childCount);
        List<BoardObject> board = new(transform.childCount + inputsContainer.childCount - 1);

        foreach (Transform input in inputsContainer) {
            board[input.GetSiblingIndex()] = inputs[input.GetSiblingIndex()] = input.GetComponent<InputButton>();
        }
        foreach (Transform gate in gatesContainer) {
            board[gate.GetSiblingIndex() + inputs.Count] = gate.GetComponent<BoardObject>();
        }
        foreach (var (outputGateIndex, inputGateIndex, inputIndex) in connections) {
            board[outputGateIndex].Outputs.Add(board[inputGateIndex]);
            board[inputGateIndex].Inputs[inputIndex] = board[outputGateIndex];

            LineRenderer wire = transform
                .Find($"Wires/Wire {outputGateIndex}-{inputGateIndex}:{inputIndex}")
                .GetComponent<LineRenderer>();
            board[inputGateIndex].Wires.Add(wire);
        }
    }

    Transform ContainerFor(int index) => 
        index < inputsContainer.childCount ? inputsContainer : 
        index < inputsContainer.childCount + gatesContainer.childCount ? gatesContainer :
        outputsContainer;

    void SetupWires()
    {
        foreach (var (outputGateIndex, inputGateIndex, inputIndex) in connections) {
            string wireName = $"Wire {outputGateIndex}-{inputGateIndex}:{inputIndex}";
            Transform wire = wiresContainer.Find(wireName);
            GameObject wireObject = wire ? wire.gameObject : new(wireName);
            LineRenderer lineRenderer = wire ? wire.GetComponent<LineRenderer>() 
                                             : wireObject.AddComponent<LineRenderer>();

            Transform outputGate = ContainerFor(outputGateIndex).Find($"Gate {outputGateIndex}");
            Transform inputGate = ContainerFor(inputGateIndex).Find($"Gate {inputGateIndex}");
            Transform outputNode = outputGate.Find("Gate Out");
            Transform inputNode = inputGate.Find($"Gate In {inputIndex}");

            Vector3 outputPosition = transform.InverseTransformPoint(outputNode.position);
            Vector3 inputPosition = transform.InverseTransformPoint(inputNode.position);

            wireObject.transform.SetParent(wiresContainer);
            wireObject.transform.localPosition = Vector3.zero;
            lineRenderer.useWorldSpace = false;

            if (outputNode.position.y != inputNode.position.y) {
                // connect via zigzag
                lineRenderer.positionCount = 4;
                float oneThird = Mathf.Lerp(outputPosition.x, inputPosition.x, 1f/3);
                float twoThirds = Mathf.Lerp(outputPosition.x, inputPosition.x, 2f/3);

                lineRenderer.SetPosition(0, outputPosition);
                lineRenderer.SetPosition(1, new Vector3(oneThird, outputPosition.y));
                lineRenderer.SetPosition(2, new Vector3(twoThirds, inputPosition.y));
                lineRenderer.SetPosition(3, inputPosition);
            } else {
                // connect directly
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, outputPosition);
                lineRenderer.SetPosition(1, inputPosition);
            }
        }
    }
}
