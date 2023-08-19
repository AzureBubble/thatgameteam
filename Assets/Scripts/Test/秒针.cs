using UnityEngine;

public class 秒针 : MonoBehaviour
{
    // Start is called before the first frame update

    public float time = 1;
    private float angle;

    private void Start()
    {
        angle = 180 / time;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.back, Time.deltaTime *angle, Space.World);
    }
}