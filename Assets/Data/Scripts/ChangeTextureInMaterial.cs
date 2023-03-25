using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaseMaterialNames
{
    public const string BaseTextureName = "_BaseTexture";
}

public class ChangeTextureInMaterial : MonoBehaviour
{
    [SerializeField]
    private Texture texture;
    [SerializeField]
    private Renderer renderer;

    private MaterialPropertyBlock propBlock;

    void Awake()
    {
        propBlock = new MaterialPropertyBlock();
       // _renderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the current value of the material properties in the renderer.
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetTexture(BaseMaterialNames.BaseTextureName, texture);
        // Apply the edited values to the renderer.
        renderer.SetPropertyBlock(propBlock);
    }

}
