using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    //����һ������
    private bool key;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��������������
        if (collision.tag == "prop")
        {   //����Ϊtrue
            key = true;
        }
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (key)
        {
            Endlevel();
        }
    }

    private void Endlevel()
    {
        //��������
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}