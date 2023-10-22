using UnityEngine;

public class Player : MonoBehaviour
{
   

    private SpriteRenderer spriteRenderer; //动画
    public Sprite[] sprite;                //公共数组用来放动画精灵组件，循环形成动画
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f; //重力大小参考现实,只有公共变量才会显示在unity面板直接调节
    public float strength = 5f;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //空格或者鼠标左键
        {
            direction = Vector3.up * strength; //每帧调用
        }

        /*if(Input.touchCount > 0) //这里是针对手游的
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }*/

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; //*Time.deltaTime的作用是不让判断以帧率为单位而是按固定时间
    }

    private void AnimateSprite()    //用于调用动画
    {
        spriteIndex++;
        if (spriteIndex >= sprite.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprite[spriteIndex];   //将精灵数组内遍历结果赋值给精灵组件，整体逻辑还是比较清楚的
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();   //不建议用这个函数，性能代价很高
        }else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
