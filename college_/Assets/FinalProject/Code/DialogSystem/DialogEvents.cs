using UnityEngine.Events;

namespace FinalProject.Code.DialogSystem
{
    public static class DialogEvents
    {
        public static UnityEvent OnDialogShownEvent = new UnityEvent();
        public static UnityEvent OnDialogHideEvent = new UnityEvent();
    }
}