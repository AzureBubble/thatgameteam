using UnityEngine;

//控制平台
public class TTest : MonoBehaviour
{
    //总时间
    public float fullTime = 10;

    //两种平台红色平台蓝色平台
    public GameObject bluePlane;

    public GameObject redPlane;

    private void Update()
    {
        Timing();
        DisappearsAndAppears();
    }

    private float waitTime;

    //倒计时
    private void Timing()
    {
        if (fullTime <= 0)
        {
            //后续应该会增加个游戏失败弹窗重新开始
            return;
        }

        waitTime += Time.deltaTime;
        if (waitTime >= 3)
        {
            fullTime--;
            Debug.Log(fullTime);
            waitTime = 0;
        }
    }

    //平台随时间出现消失函数
    public void DisappearsAndAppears()
    {
        //偶数时间蓝色平台出现红色平台消失
        if (fullTime % 2 == 0)
        {
            bluePlane.SetActive(true);
            redPlane.SetActive(false);
        }
        //奇数时间红色平台出现蓝色平台消失
        else
        {
            bluePlane.SetActive(false);
            redPlane.SetActive(true);
        }
    }
}