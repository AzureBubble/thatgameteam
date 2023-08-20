using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    //设置一个开关
    private bool key;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果触碰的是玩家
        if (collision.tag == "prop")
        {   //开关为true
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
        //打包用这个
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}