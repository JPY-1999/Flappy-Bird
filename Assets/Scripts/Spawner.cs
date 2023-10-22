using  UnityEngine;

public class Spawner : MonoBehaviour
{
   

    public GameObject prefab;
    public float spawnRate = 1f;    //���ʱ��
    public float minHeight = -1f;   //���Ӹ߶ȿ���
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);    //ÿ��spawnrate����һ������
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);   //���ɵ�pipesʵ������λ�����趨�����ɵ㣬����ת
        pipes.transform.position += Vector3.up * Random.Range(minHeight,maxHeight);         //����߶�λ��
    }
}
