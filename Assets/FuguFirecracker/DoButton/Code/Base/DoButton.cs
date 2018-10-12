using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FuguFirecracker.UI
{
    public class DoButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
        , IPointerEnterHandler, IPointerExitHandler
    {
        public Transform Transform;
        public Image[] Images;
        
        private Stack<IActionable> _actionStack = new Stack<IActionable>();

        private IActionable _actionable;

        public IActionable Actionable
        {
            get
            {
                if (_actionable != null) return _actionable;
                _actionable = GetComponent<IActionable>();
                return _actionable;
            }
        }


        private IAnimatable _animatable;

        public IAnimatable Animatable
        {
            get
            {
                if (_animatable != null) return _animatable;
                _animatable = GetComponent<IAnimatable>();
                return _animatable;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Animatable.OnDown(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Animatable.OnUp(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Animatable.OnEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Animatable.OnExit(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _actionStack.Push(Actionable);
        }

        public void Execute()
        {
            if (_actionStack.Count == 0) return;
            {
                _actionStack.Pop().Do(this);
            }
        }
    }
}