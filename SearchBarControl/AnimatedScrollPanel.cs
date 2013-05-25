namespace WineSearchBar
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public class AnimatedScrollPanel : Panel, IScrollInfo
    {
        private static readonly DependencyProperty AnimationHorizontalOffsetProperty = DependencyProperty.Register("AnimationHorizontalOffset", typeof(double), typeof(AnimatedScrollPanel), new PropertyMetadata(new PropertyChangedCallback(AnimatedScrollPanel.OnScrollChanged)));
        private static readonly DependencyProperty AnimationVerticalOffsetProperty = DependencyProperty.Register("AnimationVerticalOffset", typeof(double), typeof(AnimatedScrollPanel), new PropertyMetadata(new PropertyChangedCallback(AnimatedScrollPanel.OnScrollChanged)));
        private bool canHorizontallyScroll;
        private bool canVerticallyScroll;
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(AnimatedScrollPanel), new PropertyMetadata(new TimeSpan(0, 0, 0, 1)));
        private double extentHeight;
        private double extentWidth;
        private double horizontalOffset;
        private Storyboard storyBoard;
        private double verticalOffset;
        private double viewportHeight;
        private double viewportWidth;

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in base.Children)
            {
                element.Arrange(new Rect(-this.AnimationHorizontalOffset, -this.AnimationVerticalOffset, Math.Max(this.extentWidth, finalSize.Width), Math.Max(this.extentHeight, finalSize.Height)));
            }
            return base.ArrangeOverride(finalSize);
        }

        public void LineDown()
        {
            this.SetVerticalOffset(this.VerticalOffset + (0.1 * this.ViewportHeight));
        }

        public void LineLeft()
        {
            this.SetHorizontalOffset(this.HorizontalOffset - (0.1 * this.ViewportWidth));
        }

        public void LineRight()
        {
            this.SetHorizontalOffset(this.HorizontalOffset + (0.1 * this.ViewportWidth));
        }

        public void LineUp()
        {
            this.SetVerticalOffset(this.VerticalOffset - (0.1 * this.ViewportHeight));
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            Rect rect;
            GeneralTransform transform = visual.TransformToVisual(this);
            rect = new Rect(transform.Transform(new Point(rectangle.Left, rectangle.Top)), transform.Transform(new Point(rectangle.Right, rectangle.Bottom)));

            //modified
            rect.X = rect.X + this.HorizontalOffset;
            rect.Y = rect.Y + this.VerticalOffset;

            double horizontalOffset = this.HorizontalOffset;
            double verticalOffset = this.VerticalOffset;
            if ((horizontalOffset + this.ViewportWidth) < rect.Right)
            {
                horizontalOffset = rect.Right - this.ViewportWidth;
            }
            if ((verticalOffset + this.ViewportHeight) < rect.Bottom)
            {
                verticalOffset = rect.Bottom - this.ViewportHeight;
            }
            if (horizontalOffset > rect.Left)
            {
                horizontalOffset = rect.Left;
            }
            if (verticalOffset > rect.Top)
            {
                verticalOffset = rect.Top;
            }
            this.SetVerticalOffset(verticalOffset);
            this.SetHorizontalOffset(horizontalOffset);
            return rect;
        }

        public Rect MakeVisible(UIElement visual, Rect rectangle)
        {
            return rectangle;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size();
            foreach (UIElement element in base.Children)
            {
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }
            size.Width = base.Children.OfType<UIElement>().Max<UIElement, double>(c => c.DesiredSize.Width);
            size.Height = base.Children.OfType<UIElement>().Max<UIElement, double>(c => c.DesiredSize.Height);
            this.viewportWidth = availableSize.Width;
            this.viewportHeight = availableSize.Height;
            this.extentWidth = size.Width;
            this.extentHeight = size.Height;
            if (this.ScrollOwner != null)
            {
                this.ScrollOwner.InvalidateScrollInfo();
            }
            size.Width = Math.Min(availableSize.Width, size.Width);
            size.Height = Math.Min(availableSize.Height, size.Height);
            this.SetVerticalOffset(this.VerticalOffset);
            this.SetHorizontalOffset(this.HorizontalOffset);
            return size;
        }

        public void MouseWheelDown()
        {
            this.SetVerticalOffset(this.VerticalOffset + (0.3 * this.ViewportHeight));
        }

        public void MouseWheelLeft()
        {
            this.SetHorizontalOffset(this.HorizontalOffset - (0.3 * this.ViewportWidth));
        }

        public void MouseWheelRight()
        {
            this.SetHorizontalOffset(this.HorizontalOffset + (0.3 * this.ViewportWidth));
        }

        public void MouseWheelUp()
        {
            this.SetVerticalOffset(this.VerticalOffset - (0.3 * this.ViewportHeight));
        }

        private static void OnScrollChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as AnimatedScrollPanel).InvalidateArrange();
        }

        public void PageDown()
        {
            this.SetVerticalOffset(this.VerticalOffset + this.ViewportHeight);
        }

        public void PageLeft()
        {
            this.SetHorizontalOffset(this.HorizontalOffset - this.ViewportHeight);
        }

        public void PageRight()
        {
            this.SetHorizontalOffset(this.HorizontalOffset + this.ViewportHeight);
        }

        public void PageUp()
        {
            this.SetVerticalOffset(this.VerticalOffset - this.ViewportHeight);
        }

        public void SetHorizontalOffset(double offset)
        {
            this.horizontalOffset = Math.Max(0.0, Math.Min(this.ExtentWidth - this.ViewportWidth, offset));
            this.UpdateScrollAnimation();
            this.ScrollOwner.InvalidateScrollInfo();
        }

        public void SetVerticalOffset(double offset)
        {
            this.verticalOffset = Math.Max(0.0, Math.Min(this.ExtentHeight - this.ViewportHeight, offset));
            this.UpdateScrollAnimation();
            this.ScrollOwner.InvalidateScrollInfo();
        }

        private void UpdateScrollAnimation()
        {
            DoubleAnimation animation;
            DoubleAnimation animation2;
            if (this.storyBoard != null)
            {
                this.storyBoard.Pause();
                animation = this.storyBoard.Children[0] as DoubleAnimation;
                animation2 = this.storyBoard.Children[1] as DoubleAnimation;
            }
            else
            {
                this.storyBoard = new Storyboard();
                animation = new DoubleAnimation();
                animation2 = new DoubleAnimation();
                this.storyBoard.Children.Add(animation);
                this.storyBoard.Children.Add(animation2);
                Storyboard.SetTarget(animation, this);
                Storyboard.SetTargetProperty(animation, new PropertyPath(AnimationHorizontalOffsetProperty));
                Storyboard.SetTarget(animation2, this);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(AnimationVerticalOffsetProperty));
            }
            this.storyBoard.Duration = this.Duration;
            animation.Duration = this.Duration;
            animation2.Duration = this.Duration;
            animation.To = new double?(this.HorizontalOffset);
            animation2.To = new double?(this.VerticalOffset);
            this.storyBoard.Begin();
        }

        private double AnimationHorizontalOffset
        {
            get
            {
                return (double) base.GetValue(AnimationHorizontalOffsetProperty);
            }
            set
            {
                base.SetValue(AnimationHorizontalOffsetProperty, value);
            }
        }

        private double AnimationVerticalOffset
        {
            get
            {
                return (double) base.GetValue(AnimationVerticalOffsetProperty);
            }
            set
            {
                base.SetValue(AnimationVerticalOffsetProperty, value);
            }
        }

        public bool CanHorizontallyScroll
        {
            get
            {
                return this.canHorizontallyScroll;
            }
            set
            {
                this.canHorizontallyScroll = value;
            }
        }

        public bool CanVerticallyScroll
        {
            get
            {
                return this.canVerticallyScroll;
            }
            set
            {
                this.canVerticallyScroll = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return (TimeSpan) base.GetValue(DurationProperty);
            }
            set
            {
                base.SetValue(DurationProperty, value);
            }
        }

        public double ExtentHeight
        {
            get
            {
                return this.extentHeight;
            }
        }

        public double ExtentWidth
        {
            get
            {
                return this.extentWidth;
            }
        }

        public double HorizontalOffset
        {
            get
            {
                return this.horizontalOffset;
            }
        }

        public ScrollViewer ScrollOwner { get; set; }

        public double VerticalOffset
        {
            get
            {
                return this.verticalOffset;
            }
        }

        public double ViewportHeight
        {
            get
            {
                return this.viewportHeight;
            }
        }

        public double ViewportWidth
        {
            get
            {
                return this.viewportWidth;
            }
        }
    }
}

