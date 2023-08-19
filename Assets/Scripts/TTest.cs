using UnityEngine;

//����ƽ̨
public class TTest : MonoBehaviour
{
    //��ʱ��
    public float fullTime = 10;

    //����ƽ̨��ɫƽ̨��ɫƽ̨
    public GameObject bluePlane;

    public GameObject redPlane;

    private void Update()
    {
        Timing();
        DisappearsAndAppears();
    }

    private float waitTime;

    //����ʱ
    private void Timing()
    {
        if (fullTime <= 0)
        {
            //����Ӧ�û����Ӹ���Ϸʧ�ܵ������¿�ʼ
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

    //ƽ̨��ʱ�������ʧ����
    public void DisappearsAndAppears()
    {
        //ż��ʱ����ɫƽ̨���ֺ�ɫƽ̨��ʧ
        if (fullTime % 2 == 0)
        {
            bluePlane.SetActive(true);
            redPlane.SetActive(false);
        }
        //����ʱ���ɫƽ̨������ɫƽ̨��ʧ
        else
        {
            bluePlane.SetActive(false);
            redPlane.SetActive(true);
        }
    }
}