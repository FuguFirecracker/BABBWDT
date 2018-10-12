using DG.Tweening;
using UnityEngine;

namespace FuguFirecracker.UI
{
    public class Pulse : MonoBehaviour, IAnimatable
    {
        private Tween _tween;
        private bool _isOverButton;

        // We need to move our button up and down the SiblingIndex
        // such that it draws on top of any other elements 
        private int _siblingIndex;

        private void Awake()
        {
            _siblingIndex = GetComponent<Transform>().GetSiblingIndex();
        }

        public void OnEnter(DoButton doButton)
        {
            _isOverButton = true;

            if (_tween != null && _tween.IsActive()) _tween.Kill();
            doButton.Transform.SetAsLastSibling();
            Pulsate(doButton);
        }

        public void OnExit(DoButton doButton)
        {
            _isOverButton = false;

            _tween.Kill();
            _tween = doButton.Transform.DOScale(1, 0.2f)
                .OnComplete(() => doButton.Transform.SetSiblingIndex(_siblingIndex));
        }

        public void OnDown(DoButton doButton)
        {
            _tween.Kill();
            _tween = doButton.Transform.DOLocalRotate(new Vector3(0, 0, 180), 0.2f);
        }

        public void OnUp(DoButton doButton)
        {
            _tween.Kill();
            _tween = doButton.Transform.DOLocalRotate(Vector3.zero, 0.2f)
                .OnComplete(() =>
                {
                    if (_isOverButton)
                    {
                        _tween = doButton.Transform.DOScale(Vector3.one, 0.2f)
                            .OnComplete(() => Pulsate(doButton));
                    }
                    
                    doButton.Execute();
                });
        }

        private void Pulsate(DoButton doButton)
        {
            _tween = doButton.Transform.DOScale(1.5f, 0.3f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.OutCubic);
        }
    }
}