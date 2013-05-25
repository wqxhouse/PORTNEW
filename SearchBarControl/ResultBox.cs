namespace WineSearchBar
{
    using System;
    using System.Collections.Specialized;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

    public class ResultBox : ItemsControl
    {
        public static readonly DependencyProperty HighlightedIndexProperty = DependencyProperty.Register("HighlightedIndex", typeof(int), typeof(ResultBox), new PropertyMetadata(-1, new PropertyChangedCallback(ResultBox.OnHighlightedIndexChanged), new CoerceValueCallback(ResultBox.CoerceHighlightedIndex)));
        public static readonly DependencyProperty HighlightedItemProperty = DependencyProperty.Register("HighlightedItem", typeof(object), typeof(ResultBox), new UIPropertyMetadata(null, new PropertyChangedCallback(ResultBox.OnHighlightedItemChanged), new CoerceValueCallback(ResultBox.CoerceHighlihgtedItem)));
        private bool ignoreHighlightNotification;

        public event SearchSelectionEventHandler SearchSelection;

        static ResultBox()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBox), new FrameworkPropertyMetadata(typeof(ResultBox)));
        }

        private static object CoerceHighlightedIndex(DependencyObject d, object value)
        {
            ResultBox box = (ResultBox) d;
            int num = (int) value;
            if (num < -1)
            {
                num = -1;
            }
            if (num >= box.Items.Count)
            {
                num = box.Items.Count - 1;
            }
            if (num >= 0)
            {
                box.HighlightedItem = box.Items[num];
                return num;
            }
            box.HighlightedItem = null;
            return num;
        }

        private static object CoerceHighlihgtedItem(DependencyObject d, object value)
        {
            ResultBox box = (ResultBox) d;
            if (box.Items.Contains(value))
            {
                return value;
            }
            return null;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ResultBoxItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ResultBoxItem);
        }

        internal void NotifyHighlightedChanged(ResultBoxItem item, DependencyPropertyChangedEventArgs args)
        {
            if (((bool) args.NewValue) && !this.ignoreHighlightNotification)
            {
                this.HighlightedItem = base.ItemContainerGenerator.ItemFromContainer(item);
            }
        }

        internal void NotifyResultSelected(ResultBoxItem resultBoxItem)
        {
            if (this.SearchSelection != null)
            {
                this.SearchSelection(this, new SearchSelectionEventArgs(base.ItemContainerGenerator.ItemFromContainer(resultBoxItem)));
            }
        }

        private static void OnHighlightedIndexChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnHighlightedItemChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ResultBox box = (ResultBox) sender;
            IHighlightable highlightable = box.ItemContainerGenerator.ContainerFromItem(args.OldValue) as IHighlightable;
            if (highlightable != null)
            {
                highlightable.IsHighlighted = false;
            }
            IHighlightable highlightable2 = box.ItemContainerGenerator.ContainerFromItem(args.NewValue) as IHighlightable;
            if (highlightable2 != null)
            {
                box.ignoreHighlightNotification = true;
                highlightable2.IsHighlighted = true;
                box.ignoreHighlightNotification = false;
            }
            box.HighlightedIndex = box.Items.IndexOf(args.NewValue);
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            (element as IHighlightable).IsHighlighted = item == this.HighlightedItem;
        }

        public void ScrollIntoView(object item)
        {
            FrameworkElement element = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (element != null)
            {
                element.BringIntoView();
            }
        }

        public int HighlightedIndex
        {
            get
            {
                return (int) base.GetValue(HighlightedIndexProperty);
            }
            set
            {
                base.SetValue(HighlightedIndexProperty, value);
            }
        }

        public object HighlightedItem
        {
            get
            {
                return base.GetValue(HighlightedItemProperty);
            }
            set
            {
                base.SetValue(HighlightedItemProperty, value);
            }
        }
    }
}

