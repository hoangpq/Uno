﻿using Uno.UI.Controls;
using Uno.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media;
using Uno.Logging;
using System.Drawing;
using System.Linq;
using Uno.Disposables;
using Uno.UI;
using View = Windows.UI.Xaml.UIElement;

namespace Windows.UI.Xaml.Controls
{
	public partial class Control
	{
		public Control()
		{
			InitializeControl();
		}

		partial void UnregisterSubView()
		{
			//var child = this.GetChildren()?.FirstOrDefault();
			//if (child != null)
			//{
			//	RemoveChild(child);
			//}
		}

		partial void RegisterSubView(View child)
		{
			AddChild(child);
		}

		/// <summary>
		/// Gets the first sub-view of this control or null if there is none
		/// </summary>
		public IFrameworkElement GetTemplateRoot()
		{
			return this.GetChildren()?.FirstOrDefault() as IFrameworkElement;
		}

		protected virtual bool RequestFocus(FocusState state)
		{
			FocusState = state;

			return true;
		}

		partial void OnFocusStateChangedPartial(FocusState oldValue, FocusState newValue)
		{
			//if (newValue == FocusState.Pointer && Focusable)
			//{
			//	//Set native focus to this view
			//	RequestFocus();
			//}
		}
	}
}
