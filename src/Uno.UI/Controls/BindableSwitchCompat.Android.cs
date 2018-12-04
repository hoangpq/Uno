﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.Util;
using Android.Widget;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Controls
{
	public partial class BindableSwitchCompat : Android.Support.V7.Widget.SwitchCompat, DependencyObject
	{
		public BindableSwitchCompat()
			: base(ContextHelper.Current)
		{
			InitializeBinder();

			CheckedChange += OnCheckedChange;
			TextChanged += OnTextChange;

			// TextOn and TextOff properties must be set to an empty string or the following error will happen because the properties are null.
			// E / AndroidRuntime(6313): java.lang.NullPointerException: Attempt to invoke interface method 'int java.lang.CharSequence.length()' on a null object reference
			// E / AndroidRuntime(6313): 	at android.text.StaticLayout.< init > (StaticLayout.java:49)
			// E / AndroidRuntime(6313): 	at android.support.v7.widget.SwitchCompat.makeLayout(SwitchCompat.java:606)
			// E / AndroidRuntime(6313): 	at android.support.v7.widget.SwitchCompat.onMeasure(SwitchCompat.java:526)
			// E / AndroidRuntime(6313): 	at android.view.View.measure(View.java:17547)

			TextOn = "";
			TextOff = "";
		}

		#region TextColor DependencyProperty

		/// <summary> 
		/// The color used to change the text header foreground.
		/// </summary>
		public Brush TextColor
		{
			get { return (Brush)this.GetValue(TextColorProperty); }
			set { this.SetValue(TextColorProperty, value); }
		}

		public static readonly DependencyProperty TextColorProperty =
			DependencyProperty.Register("TextColor", typeof(Brush), typeof(BindableSwitchCompat), new PropertyMetadata(null, (s, e) => ((BindableSwitchCompat)s).OnTextColorChanged((Brush)e.NewValue)));

		private void OnTextColorChanged(Brush newValue)
		{
			if (newValue is SolidColorBrush asColorBrush)
				{
				SetTextColor(asColorBrush.Color);
			}
		}

		#endregion

		#region ThumbTint DependencyProperty

		/// <summary> 
		/// The color used to tint the appearance of the thumb.
		/// </summary>
		public Brush ThumbTint
		{
			get { return (Brush)this.GetValue(ThumbTintProperty); }
			set { this.SetValue(ThumbTintProperty, value); }
		}

		public static readonly DependencyProperty ThumbTintProperty =
			DependencyProperty.Register("ThumbTint", typeof(Brush), typeof(BindableSwitchCompat), new PropertyMetadata(null, (s, e) => ((BindableSwitchCompat)s).OnThumbTintChanged((Brush)e.NewValue)));

		private void OnThumbTintChanged(Brush newValue)
		{
			if (newValue is SolidColorBrush asColorBrush)
			{
				ThumbTintList = ColorStateList.ValueOf(asColorBrush.Color);
			}
		}

		#endregion

		#region TrackTint DependencyProperty

		/// <summary> 
		/// The color used to tint the appearance of the track.
		/// </summary>
		public Brush TrackTint
		{
			get { return (Brush)this.GetValue(TrackTintProperty); }
			set { this.SetValue(TrackTintProperty, value); }
		}

		public static readonly DependencyProperty TrackTintProperty =
			DependencyProperty.Register("TrackTint", typeof(Brush), typeof(BindableSwitchCompat), new PropertyMetadata(null, (s, e) => ((BindableSwitchCompat)s).OnTrackTintChanged((Brush)e.NewValue)));

		private void OnTrackTintChanged(Brush newValue)
		{
			if (newValue is SolidColorBrush asColorBrush)
			{
				TrackTintList = ColorStateList.ValueOf(asColorBrush.Color);
			}
		}

		#endregion

		private void OnCheckedChange(object sender, CheckedChangeEventArgs e)
		{
			SetBindingValue(Checked, "Checked");
		}

		private void OnTextChange(object sender, TextChangedEventArgs e)
		{
			SetBindingValue(Text, "Text");
		}

		public BindableSwitchCompat(Android.Content.Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public BindableSwitchCompat(Android.Content.Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}
	}
}