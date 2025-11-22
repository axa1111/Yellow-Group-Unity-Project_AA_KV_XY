using UnityEngine;
public class HighlightItems : MonoBehaviour
{
    [SerializeField] private RenderingLayerMask outlineLayer;
  
    private Renderer[] renderers;  
    private uint originalLayer;



    private void Start()
    {
        renderers = TryGetComponent<Renderer>(out var meshRenderer)
            ? new[] { meshRenderer }
            : GetComponentsInChildren<Renderer>();
        originalLayer = renderers[0].renderingLayerMask;
        TurnOutlineOn();
    }

    public void TurnOutlineOn()
    {
        SetOutline(true);
    }

    private void OnMouseDown()
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
