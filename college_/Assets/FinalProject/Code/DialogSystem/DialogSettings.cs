using UnityEngine;

namespace FinalProject.Code.DialogSystem
{
    [CreateAssetMenu(fileName = "DialogSettings", menuName = "Dialog/DialogSettings", order = 0)]
    public class DialogSettings : ScriptableObject
    {
        [SerializeField]
        private string[] _dialogStrings;

        public string[] DialogStrings
        {
            get => _dialogStrings;
        }
    }
}