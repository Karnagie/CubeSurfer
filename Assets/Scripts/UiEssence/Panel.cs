using UnityEngine;

namespace UiEssence
{
    public abstract class Panel : MonoBehaviour
    {
        protected virtual void Show()
        {
            gameObject.SetActive(true);
        }

        protected virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}