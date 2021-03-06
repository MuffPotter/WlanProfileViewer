﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace WlanProfileViewer.Views.Controls
{
	[TemplatePart(Name = "PART_LevelOne", Type = typeof(Shape))]
	[TemplatePart(Name = "PART_LevelTwo", Type = typeof(Shape))]
	[TemplatePart(Name = "PART_LevelThree", Type = typeof(Shape))]
	[TemplatePart(Name = "PART_LevelFour", Type = typeof(Shape))]
	[TemplatePart(Name = "PART_LevelFive", Type = typeof(Shape))]
	public class SignalProgressBar : ProgressBar
	{
		public SignalProgressBar()
		{ }

		static SignalProgressBar()
		{
			RangeBase.ValueProperty.OverrideMetadata(
				typeof(SignalProgressBar),
				new FrameworkPropertyMetadata(
					0D,
					(d, e) => ((SignalProgressBar)d).RenderLevel()));
		}

		#region Template Part

		private Shape _levelOne;
		private Shape _levelTwo;
		private Shape _levelThree;
		private Shape _levelFour;
		private Shape _levelFive;

		#endregion

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_levelOne = this.GetTemplateChild("PART_LevelOne") as Shape;
			_levelTwo = this.GetTemplateChild("PART_LevelTwo") as Shape;
			_levelThree = this.GetTemplateChild("PART_LevelThree") as Shape;
			_levelFour = this.GetTemplateChild("PART_LevelFour") as Shape;
			_levelFive = this.GetTemplateChild("PART_LevelFive") as Shape;

			RenderLevel();
		}

		private void RenderLevel()
		{
			if ((_levelOne == null) ||
				(_levelTwo == null) ||
				(_levelThree == null) ||
				(_levelFour == null) ||
				(_levelFive == null))
				return;

			var percentage = this.Value * 100D / this.Maximum;

			_levelOne.Fill = (this.Value == 0D) ? this.Background : this.Foreground;
			_levelTwo.Fill = (percentage <= 20D) ? this.Background : this.Foreground;
			_levelThree.Fill = (percentage <= 40D) ? this.Background : this.Foreground;
			_levelFour.Fill = (percentage <= 60D) ? this.Background : this.Foreground;
			_levelFive.Fill = (percentage <= 80D) ? this.Background : this.Foreground;
		}
	}
}