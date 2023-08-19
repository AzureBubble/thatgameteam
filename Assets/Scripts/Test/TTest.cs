using UnityEngine;

//控制平台
public class TTest : MonoBehaviour
{
    //总时间
    public float fullTime = 60;

    //两种平台红色平台蓝色平台
    public GameObject[] bluePlane;

    public GameObject[] redPlane;

    public GameObject zhen;
    
    private float waitTime;
    private float setTime ;

    private void Update()
    {

        Timing();
        DisappearsAndAppears();
        setTime = zhen.GetComponent<秒针>().time/2;
    }

    

    //倒计时
    public void Timing()
    {
        if (fullTime <= 0)
        {
            //后续应该会增加个游戏失败弹窗重新开始
            return;
        }

        waitTime += Time.deltaTime;
        if (waitTime >= setTime)
        {
            fullTime--;
            //Debug.Log(fullTime);
            waitTime = 0;
        }
    }

    //平台随时间出现消失函数
    public void DisappearsAndAppears()
    {
        //偶数时间蓝色平台出现红色平台消失
        if (fullTime % 2 == 0)
        {
            for (int i = 0; i < bluePlane.Length; i++)
            {
                bluePlane[i].SetActive(true);
            }

            for (int i = 0; i < redPlane.Length; i++)
            {
                redPlane[i].SetActive(false);
            }
            
        }
        //奇数时间红色平台出现蓝色平台消失
        else
        {
            for (int i = 0; i < bluePlane.Length; i++)
            {
                bluePlane[i].SetActive(false);
            }

            for (int i = 0; i < redPlane.Length; i++)
            {
                redPlane[i].SetActive(true);
            }

        }
    }


}