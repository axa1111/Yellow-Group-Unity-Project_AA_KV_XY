using UnityEngine;
//https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@14.0/manual/features/rendering-layers.html
//this script sits on all the interactable items on the treatment scne
//it manages the outline which is shown when the raycast hist is 
public class HighlightItems : MonoBehaviour
{
    [SerializeField] private RenderingLayerMask outlineLayer;

    private Renderer[] renderers; //store all renderer componenets in ray
    private uint originalLayer;



    private void Start()
    {
        renderers = TryGetComponent<Renderer>(out var meshRenderer)
            ? new[] { meshRenderer }
            : GetComponentsInChildren<Renderer>();
        originalLayer = renderers[0].renderingLayerMask;
        //TurnOutlineOn();
    }

//turn on the outline
    public void TurnOutlineOn()
    {
        SetOutline(true);
    }

//turn off the outline
    public void TurnOutlineOff()
    {
        SetOutline(false);
    }

    private void SetOutline(bool enable)
    {
        foreach (var rend in renderers)
        {
            rend.renderingLayerMask = enable
            ? originalLayer | outlineLayer
            : originalLayer;
        }
    }
}
