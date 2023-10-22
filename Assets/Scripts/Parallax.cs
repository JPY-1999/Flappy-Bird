using UnityEngine;

public class Parallax : MonoBehaviour  //Parallax���Ӳ�   Unlit��Ⱦ������һ�ֻ�������������Խ�����ɫ����Ⱦ��ʽ��
                                       //�������ǹ��ա���Ӱ�ȸ��ӵ�Ч����ֻ��ע����������ɫ������
                                       //��ˣ����Ƚ��ʺ�����ʵ��2D��Ϸ��򵥵�3D��Ϸ���ܹ������Ϸ����ȾЧ�ʡ�
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.05f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0);  //�ı�offset������ֻ��x��
    }
}
