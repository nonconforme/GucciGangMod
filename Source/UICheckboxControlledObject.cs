//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Checkbox Controlled Object")]
public class UICheckboxControlledObject : MonoBehaviour
{
    public bool inverse;
    public GameObject target;

    private void OnActivate(bool isActive)
    {
        if (target != null)
        {
            NGUITools.SetActive(target, !inverse ? isActive : !isActive);
            var panel = NGUITools.FindInParents<UIPanel>(target);
            if (panel != null)
            {
                panel.Refresh();
            }
        }
    }

    private void OnEnable()
    {
        var component = GetComponent<UICheckbox>();
        if (component != null)
        {
            OnActivate(component.isChecked);
        }
    }
}

