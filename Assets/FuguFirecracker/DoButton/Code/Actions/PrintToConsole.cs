using UnityEngine;

namespace FuguFirecracker.UI
{
    public class PrintToConsole : MonoBehaviour, IActionable
    {
        [SerializeField] private string _message;

        public void Do(DoButton doButton)
        {
            Debug.Log(_message);
        }
    }
}