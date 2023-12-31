using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerItem : MonoBehaviour, IOperable
{
    [SerializeField] UnityEvent<bool> OnActivedEvent;
    [field: SerializeField] public PlayerItemDataSO ItemData { get; private set; }

    /// <summary>
    /// actions to be performed when an item just activated
    /// </summary>
    /// <returns>active succeed</returns>
    protected abstract bool OnActiveItem(GameObject performer);

    public bool Operate(GameObject performer)
    {
        bool result = OnActiveItem(performer);
        OnActivedEvent?.Invoke(result);
        return result;
    }
}
