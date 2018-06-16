using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Noyau.Omnitech.Scripts
{
    public sealed class Omnitech : MonoBehaviour
    {
        [SerializeField]
        private Transform m_screen = null;
        [SerializeField]
        private Vector3 m_screenOnScale = Vector3.one;
        [SerializeField]
        private float m_screenAnimDuration = .2F;
        [SerializeField]
        private bool m_screenVisible = false;

        private void OnScreenUpdate()
        {
            Sequence _anim = DOTween.Sequence();
            _anim.AppendCallback(() => m_screen.gameObject.SetActive(true));
            _anim.Append(m_screen.DOScale(m_screenVisible ? Vector3.zero : m_screenOnScale, 0F));
            _anim.Append(m_screen.DOScale(m_screenVisible ? m_screenOnScale : Vector3.zero, m_screenAnimDuration));
            if (!m_screenVisible)
                _anim.AppendCallback(() => m_screen.gameObject.SetActive(false));
        }

        private void OnValidate()
        {
            m_screenAnimDuration = Mathf.Max(m_screenAnimDuration, 0F);
        }

        private void Reset()
        {
            List<Transform> _children = new List<Transform>();
            GetComponentsInChildren(true, _children);
            m_screen = _children.Find(_t => _t.name.Contains("Screen"));
        }

        private void Awake()
        {
            m_screen.gameObject.SetActive(false);
        }
    } // class: Omnitech
} // namespace