using UnityEngine;

public class 秒针 : MonoBehaviour
{
    // Start is called before the first frame update

    public float time = 1;
    private float angle;

    bool isStop;
    private void OnPlayerDeadEvent()
    {
        isStop = true;
    }

    bool isWin;

    private void OnVictoryEvent()
    {
        isWin = true;
    }

    private void Start()
    {
        angle = 180 / time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isStop == false||isWin ==false)
        {
            transform.Rotate(Vector3.back, Time.deltaTime * angle, Space.World);
        }
        

    }






}