﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace OmiyaGames.Menu
{
    ///-----------------------------------------------------------------------
    /// <copyright file="UiEventNavigation.cs" company="Omiya Games">
    /// The MIT License (MIT)
    /// 
    /// Copyright (c) 2014-2018 Omiya Games
    /// 
    /// Permission is hereby granted, free of charge, to any person obtaining a copy
    /// of this software and associated documentation files (the "Software"), to deal
    /// in the Software without restriction, including without limitation the rights
    /// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    /// copies of the Software, and to permit persons to whom the Software is
    /// furnished to do so, subject to the following conditions:
    /// 
    /// The above copyright notice and this permission notice shall be included in
    /// all copies or substantial portions of the Software.
    /// 
    /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    /// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    /// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    /// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    /// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    /// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    /// THE SOFTWARE.
    /// </copyright>
    /// <author>Taro Omiya</author>
    /// <date>7/12/2018</date>
    ///-----------------------------------------------------------------------
    /// <summary>
    /// A script to handle navigation on select.
    /// </summary>
    /// <remarks>
    /// Revision History:
    /// <list type="table">
    /// <listheader>
    /// <description>Date</description>
    /// <description>Name</description>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <description>7/12/2018</description>
    /// <description>Taro</description>
    /// <description>Initial verison</description>
    /// </item>
    /// </list>
    /// </remarks>
    [DisallowMultipleComponent]
    public class UiEventNavigation : MonoBehaviour, ISelectHandler
    {
        public event System.Action<UiEventNavigation, BaseEventData> OnAfterSelect;
        public event System.Action<UiEventNavigation, bool> OnAfterEnabledAndActiveChanged;

        RectTransform rectTransform = null;

        public RectTransform RectTransform
        {
            get
            {
                if(rectTransform == null)
                {
                    rectTransform = transform as RectTransform;
                }
                return rectTransform;
            }
        }

        public virtual void OnSelect(BaseEventData eventData)
        {
            OnAfterSelect?.Invoke(this, eventData);
        }

        public virtual void OnEnable()
        {
            OnAfterEnabledAndActiveChanged?.Invoke(this, true);
        }

        public virtual void OnDisable()
        {
            OnAfterEnabledAndActiveChanged?.Invoke(this, false);
        }
    }
}