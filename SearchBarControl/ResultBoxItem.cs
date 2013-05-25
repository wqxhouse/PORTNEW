using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WineSearchBar
{
    

    public class ResultBoxItem : ContentControl, IHighlightable
    {
        public static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(ResultBoxItem), new PropertyMetadata(false, new PropertyChangedCallback(ResultBoxItem.OnIsHighlightedChanged)));

        static ResultBoxItem()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBoxItem), new FrameworkPropertyMetadata(typeof(ResultBoxItem)));
        }

        private static void OnIsHighlightedChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ResultBoxItem item = (ResultBoxItem) sender;
            item.ParentResultBox.NotifyHighlightedChanged(item, args);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            this.IsHighlighted = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            this.IsHighlighted = true;
            this.ParentResultBox.NotifyResultSelected(this);
        }

        public bool IsHighlighted
        {
            get
            {
                return (bool) base.GetValue(IsHighlightedProperty);
            }
            set
            {
                base.SetValue(IsHighlightedProperty, value);
            }
        }

        internal ResultBox ParentResultBox
        {
            get
            {
                return (ItemsControl.ItemsControlFromItemContainer(this) as ResultBox);
            }
        }
    }
}

