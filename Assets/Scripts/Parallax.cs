using UnityEngine;

public class Parallax : MonoBehaviour  //Parallax：视差   Unlit渲染管线是一种基于物体表面属性进行着色的渲染方式，
                                       //它不考虑光照、阴影等复杂的效果，只关注物体表面的颜色和纹理。
                                       //因此，它比较适合用于实现2D游戏或简单的3D游戏，能够提高游戏的渲染效率。
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.05f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0);  //改变offset参数，只动x轴
    }
}
