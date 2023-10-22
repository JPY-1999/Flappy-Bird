using  UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;  //
    }

    private void Update()
    {
        transform.position +=  speed * Time.deltaTime * Vector3.left; //让pipes向左移动起来

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
