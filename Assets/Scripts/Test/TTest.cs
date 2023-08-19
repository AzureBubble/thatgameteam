using UnityEngine;

//����ƽ̨
public class TTest : MonoBehaviour
{
    //��ʱ��
    public float fullTime = 60;

    //����ƽ̨��ɫƽ̨��ɫƽ̨
    public GameObject[] bluePlane;

    public GameObject[] redPlane;

    public GameObject zhen;
    
    private float waitTime;
    private float setTime ;

    private void Update()
    {

        Timing();
        DisappearsAndAppears();
        setTime = zhen.GetComponent<����>().time/2;
    }

    

    //����ʱ
    public void Timing()
    {
        if (fullTime <= 0)
        {
            //����Ӧ�û����Ӹ���Ϸʧ�ܵ������¿�ʼ
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

    //ƽ̨��ʱ�������ʧ����
    public void DisappearsAndAppears()
    {
        //ż��ʱ����ɫƽ̨���ֺ�ɫƽ̨��ʧ
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
        //����ʱ���ɫƽ̨������ɫƽ̨��ʧ
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