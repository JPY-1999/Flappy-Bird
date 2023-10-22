using UnityEngine;

public class Player : MonoBehaviour
{
   

    private SpriteRenderer spriteRenderer; //����
    public Sprite[] sprite;                //�������������Ŷ������������ѭ���γɶ���
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f; //������С�ο���ʵ,ֻ�й��������Ż���ʾ��unity���ֱ�ӵ���
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //�ո����������
        {
            direction = Vector3.up * strength; //ÿ֡����
        }

        /*if(Input.touchCount > 0) //������������ε�
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }*/

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; //*Time.deltaTime�������ǲ����ж���֡��Ϊ��λ���ǰ��̶�ʱ��
    }

    private void AnimateSprite()    //���ڵ��ö���
    {
        spriteIndex++;
        if (spriteIndex >= sprite.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprite[spriteIndex];   //�����������ڱ��������ֵ����������������߼����ǱȽ������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();   //��������������������ܴ��ۺܸ�
        }else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
