using  UnityEngine;

public class Spawner : MonoBehaviour
{
   

    public GameObject prefab;
    public float spawnRate = 1f;    //间隔时间
    public float minHeight = -1f;   //柱子高度控制
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);    //每隔spawnrate生成一个柱子
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);   //生成的pipes实例化，位置是设定的生成点，无旋转
        pipes.transform.position += Vector3.up * Random.Range(minHeight,maxHeight);         //随机高度位置
    }
}
