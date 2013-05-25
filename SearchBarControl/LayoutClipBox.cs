namespace WineSearchBar
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System.Windows.Threading;

    public class LayoutClipBox : Panel
    {
        private bool invalidationQueued;
        public static readonly DependencyProperty LayoutAnimationDurationProperty = DependencyProperty.Register("LayoutAnimationDuration", typeof(TimeSpan), typeof(LayoutClipBox), new UIPropertyMetadata(new TimeSpan(0, 0, 0, 0, 330)));
        public static readonly DependencyProperty LayoutScaleXProperty = DependencyProperty.Register("LayoutScaleX", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(1.0, new PropertyChangedCallback(LayoutClipBox.OnLayoutScalePropertyChanged)));
        public static readonly DependencyProperty LayoutScaleYProperty = DependencyProperty.Register("LayoutScaleY", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(1.0, new PropertyChangedCallback(LayoutClipBox.OnLayoutScalePropertyChanged)));
        private Size? previousSize;
        public static readonly DependencyProperty SelfLayoutScaleXProperty = DependencyProperty.Register("SelfLayoutScaleX", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(0.0, new PropertyChangedCallback(LayoutClipBox.OnInternalResizePropertyChanged)));
        public static readonly DependencyProperty SelfLayoutScaleYProperty = DependencyProperty.Register("SelfLayoutScaleY", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(0.0, new PropertyChangedCallback(LayoutClipBox.OnInternalResizePropertyChanged)));
        private Storyboard selfscale;

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in base.Children)
            {
                element.Arrange(new Rect(0.0, 0.0, finalSize.Width, finalSize.Height));
            }
            return finalSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();
            foreach (UIElement element in base.Children)
            {
                element.Measure(constraint);
                size.Width = Math.Max(element.DesiredSize.Width, size.Width);
                size.Height = Math.Max(element.DesiredSize.Height, size.Height);
            }
            if (!this.previousSize.HasValue)
            {
                this.previousSize = new Size?(size);
                this.SelfLayoutScaleX = size.Width;
                this.SelfLayoutScaleY = size.Height;
            }
            else if (this.previousSize.HasValue && (this.previousSize.Value != size))
            {
                Storyboard storyboard = new Storyboard();
                DoubleAnimation animation = new DoubleAnimation {
                    From = new double?(this.SelfLayoutScaleX),
                    To = new double?(size.Width),
                    Duration = new Duration(this.LayoutAnimationDuration),
                    DecelerationRatio = 1.0
                };
                Storyboard.SetTarget(animation, this);
                Storyboard.SetTargetProperty(animation, new PropertyPath(SelfLayoutScaleXProperty));
                storyboard.Children.Add(animation);
                animation = new DoubleAnimation {
                    From = new double?(this.SelfLayoutScaleY),
                    To = new double?(size.Height),
                    Duration = new Duration(this.LayoutAnimationDuration),
                    DecelerationRatio = 1.0
                };
                Storyboard.SetTarget(animation, this);
                Storyboard.SetTargetProperty(animation, new PropertyPath(SelfLayoutScaleYProperty));
                storyboard.Children.Add(animation);
                if (this.selfscale != null)
                {
                    this.selfscale.Pause();
                    this.selfscale.Remove();
                }
                this.selfscale = storyboard;
                this.selfscale.Begin();
                this.previousSize = new Size?(size);
            }
            return new Size(this.SelfLayoutScaleX * this.LayoutScaleX, this.SelfLayoutScaleY * this.LayoutScaleY);
        }

        private static void OnInternalResizePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            LayoutClipBox box = (LayoutClipBox) sender;
            if (box != null)
            {
                box.QueueLayoutInvalidation();
            }
        }

        private static void OnLayoutScalePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            LayoutClipBox box = (LayoutClipBox) sender;
            if (box != null)
            {
                box.QueueLayoutInvalidation();
            }
        }

        private void QueueLayoutInvalidation()
        {
            Action method = null;
            if (!this.invalidationQueued)
            {
                this.invalidationQueued = true;
                if (method == null)
                {
                    method = delegate {
                        base.InvalidateMeasure();
                        this.invalidationQueued = false;
                    };
                }
                base.Dispatcher.BeginInvoke(DispatcherPriority.Input, method);
            }
        }

        public TimeSpan LayoutAnimationDuration
        {
            get
            {
                return (TimeSpan) base.GetValue(LayoutAnimationDurationProperty);
            }
            set
            {
                base.SetValue(LayoutAnimationDurationProperty, value);
            }
        }

        public double LayoutScaleX
        {
            get
            {
                return (double) base.GetValue(LayoutScaleXProperty);
            }
            set
            {
                base.SetValue(LayoutScaleXProperty, value);
            }
        }

        public double LayoutScaleY
        {
            get
            {
                return (double) base.GetValue(LayoutScaleYProperty);
            }
            set
            {
                base.SetValue(LayoutScaleYProperty, value);
            }
        }

        public double SelfLayoutScaleX
        {
            get
            {
                return (double) base.GetValue(SelfLayoutScaleXProperty);
            }
            private set
            {
                base.SetValue(SelfLayoutScaleXProperty, value);
            }
        }

        public double SelfLayoutScaleY
        {
            get
            {
                return (double) base.GetValue(SelfLayoutScaleYProperty);
            }
            set
            {
                base.SetValue(SelfLayoutScaleYProperty, value);
            }
        }
    }
}

