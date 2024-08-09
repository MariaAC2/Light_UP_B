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

    [SerializeField] private List<Connection> connections = new();

    // Start is called before the first frame update
    void Start()
    {
        SetupWires();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.IsPlaying(gameObject)) {
            SetupWires();
        }
    }

    void SetupWires()
    {
        foreach (var (outputGateIndex, inputGateIndex, inputIndex) in connections) {
            string wireName = $"Wire {outputGateIndex}-{inputGateIndex}:{inputIndex}";
            Transform wire = transform.Find(wireName);
            GameObject wireObject = wire ? wire.gameObject : new(wireName);
            LineRenderer lineRenderer = wire ? wire.GetComponent<LineRenderer>() 
                                             : wireObject.AddComponent<LineRenderer>();

            Transform outputGate = transform.Find($"Gate {outputGateIndex}");
            Transform inputGate = transform.Find($"Gate {inputGateIndex}");
            Transform outputNode = outputGate.Find("Gate Out");
            Transform inputNode = inputGate.Find($"Gate In {inputIndex}");

            Vector3 outputPosition = transform.InverseTransformPoint(outputNode.position);
            Vector3 inputPosition = transform.InverseTransformPoint(inputNode.position);

            wireObject.transform.SetParent(transform);
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
