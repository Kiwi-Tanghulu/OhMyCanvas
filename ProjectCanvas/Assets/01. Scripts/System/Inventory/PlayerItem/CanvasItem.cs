using UnityEngine;

public class CanvasItem : PlayerItem
{
    protected override bool OnActiveItem(GameObject performer)
    {
        Debug.Log($"canvas installed");
        return true;
    }
}
