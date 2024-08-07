using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float offsetY = 10f;

    [SerializeField] Transform player;

    private void Update()
    {
        transform.position = player.position + new Vector3(0, offsetY, 0);
    }
}
