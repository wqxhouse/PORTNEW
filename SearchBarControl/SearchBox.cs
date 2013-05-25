namespace WineSearchBar
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Threading;

    public class SearchBox : Control
    {
        private CollectionViewSource collectionViewSource;
        private ObservableCollection<GroupDescription> groupDescriptions;
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(SearchBox), new PropertyMetadata(false, new PropertyChangedCallback(SearchBox.OnIsOpenChanged)));
        public static readonly DependencyProperty ResultEmptyContentProperty = DependencyProperty.Register("ResultEmptyContent", typeof(object), typeof(SearchBox), null);
        public static readonly DependencyProperty ResultEmptyContentTemplateProperty = DependencyProperty.Register("ResultEmptyContentTemplate", typeof(DataTemplate), typeof(SearchBox), null);
        private ObservableCollection<GroupStyle> resultGroupStyle;
        public static readonly DependencyProperty ResultItemContainerStyleProperty = DependencyProperty.Register("ResultItemContainerStyle", typeof(Style), typeof(SearchBox), null);
        public static readonly DependencyProperty ResultItemContainerStyleSelectorProperty = DependencyProperty.Register("ResultItemContainerStyleSelector", typeof(StyleSelector), typeof(SearchBox), null);
        public static readonly DependencyProperty ResultItemTemplateProperty = DependencyProperty.Register("ResultItemTemplate", typeof(DataTemplate), typeof(SearchBox), null);
        public static readonly DependencyProperty ResultListBoxStyleProperty = DependencyProperty.Register("ResultListBoxStyle", typeof(Style), typeof(SearchBox), null);
        private TextBox searchBox;
        private ResultBox searchList;
        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(SearchBox), new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(SearchBox.OnSearchTextChanged)));
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(IEnumerable), typeof(SearchBox), new PropertyMetadata(null, new PropertyChangedCallback(SearchBox.OnSourceChanged)));
        public static readonly DependencyProperty ViewProperty = DependencyProperty.Register("View", typeof(ICollectionView), typeof(SearchBox), null);

        public event SearchFilterEventHandler Filter;

        public event SearchSelectionEventHandler SearchSelection;

        static SearchBox()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(typeof(SearchBox)));
            Control.IsTabStopProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(false));
            EventManager.RegisterClassHandler(typeof(SearchBox), Keyboard.KeyDownEvent, new RoutedEventHandler(SearchBox.OnHandledKeyDown), true);
        }

        public SearchBox()
        {
            base.IsMouseCaptureWithinChanged += new DependencyPropertyChangedEventHandler(this.OnIsMouseCaptureWithinChanged);
            base.IsKeyboardFocusWithinChanged += new DependencyPropertyChangedEventHandler(this.OnIsKeyboardFocusWithinChanged);
            this.groupDescriptions = new ObservableCollection<GroupDescription>();
            this.GroupDescriptions.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnGroupDescriptionsCollectionChanged);
            this.resultGroupStyle = new ObservableCollection<GroupStyle>();
            this.ResultGroupStyle.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnResultGroupStyleCollectionChanged);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.searchBox != null)
            {
                this.searchBox.GotFocus -= new RoutedEventHandler(this.OnSearchBoxGotFocus);
            }
            this.searchBox = base.GetTemplateChild("PART_SearchBox") as TextBox;
            if (this.searchBox != null)
            {
                this.searchBox.GotFocus += new RoutedEventHandler(this.OnSearchBoxGotFocus);
            }
            if (this.searchList != null)
            {
                this.searchList.SearchSelection -= new SearchSelectionEventHandler(this.OnResultListSearchSelection);
            }
            this.searchList = base.GetTemplateChild("PART_SearchList") as ResultBox;
            if (this.searchList != null)
            {
                this.PropagateResultGroupStyleToSearchList();
                this.searchList.SearchSelection += new SearchSelectionEventHandler(this.OnResultListSearchSelection);
                this.searchList.HighlightedIndex = 0;
            }
        }

        private void OnCollectionViewSourceFilter(object sender, FilterEventArgs e)
        {
            if (this.Filter != null)
            {
                this.Filter(this, new SearchFilterEventArgs(this.SearchText, e));
            }
        }

        private void OnGroupDescriptionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.PropagateGroupDescriptionsToCollectionView();
        }

        private void OnHandledKeyDown(KeyEventArgs e)
        {
            if ((this.IsOpen && (!e.Handled || (e.Handled && (e.OriginalSource == this.searchBox)))) && (this.searchList != null))
            {
                switch (e.Key)
                {
                    case Key.Prior:
                        this.searchList.HighlightedIndex = Math.Max(0, this.searchList.HighlightedIndex - 10);
                        this.searchList.ScrollIntoView(this.searchList.HighlightedItem);
                        return;

                    case Key.Next:
                        this.searchList.HighlightedIndex += 10;
                        this.searchList.ScrollIntoView(this.searchList.HighlightedItem);
                        return;

                    case Key.Return:
                        this.OnSearchSelection();
                        return;

                    case Key.Up:
                        this.searchList.HighlightedIndex = Math.Max(0, this.searchList.HighlightedIndex - 1);
                        this.searchList.ScrollIntoView(this.searchList.HighlightedItem);
                        return;

                    case Key.Right:
                        return;

                    case Key.Down:
                        this.searchList.HighlightedIndex++;
                        this.searchList.ScrollIntoView(this.searchList.HighlightedItem);
                        return;
                }
            }
        }

        private static void OnHandledKeyDown(object sender, RoutedEventArgs e)
        {
            ((SearchBox) sender).OnHandledKeyDown(e as KeyEventArgs);
        }

        private void OnIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!((bool) e.NewValue))
            {
                this.IsOpen = false;
            }
        }

        private void OnIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsOpen && !((bool) e.NewValue))
            {
                Mouse.Capture(this, CaptureMode.SubTree);
            }
        }

        private void OnIsOpenChanged(DependencyPropertyChangedEventArgs args)
        {
            if ((bool) args.NewValue)
            {
                Mouse.Capture(this, CaptureMode.SubTree);
            }
            else
            {
                Mouse.Capture(null);
                this.SearchText = string.Empty;
            }
        }

        private static void OnIsOpenChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox) sender).OnIsOpenChanged(args);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((this.IsOpen && !e.Handled) && (e.Key == Key.Escape))
            {
                this.IsOpen = false;
                if (this.searchBox != null)
                {
                    this.searchBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if ((e.OriginalSource == this) && this.IsOpen)
            {
                this.IsOpen = false;
                base.Focus();
                e.Handled = true;
            }
        }

        private void OnResultGroupStyleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.PropagateResultGroupStyleToSearchList();
        }

        private void OnResultListSearchSelection(object sender, SearchSelectionEventArgs e)
        {
            this.OnSearchSelection();
        }

        protected void OnSearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            this.IsOpen = true;
        }

        private void OnSearchListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.OnSearchSelection();
        }

        private void OnSearchSelection()
        {
            if (((this.SearchSelection != null) && (this.searchList != null)) && (this.searchList.HighlightedItem != null))
            {
                this.SearchSelection(this, new SearchSelectionEventArgs(this.searchList.HighlightedItem));
                this.IsOpen = false;
                base.Focus();
            }
        }

        private void OnSearchTextChanged(DependencyPropertyChangedEventArgs args)
        {
            Action method = null;
            if ((this.collectionViewSource != null) && (this.collectionViewSource.View != null))
            {
                if (method == null)
                {
                    method = delegate {
                        if (this.collectionViewSource != null)
                        {
                            this.collectionViewSource.View.Refresh();
                            if (this.searchList != null)
                            {
                                this.searchList.HighlightedIndex = 0;
                            }
                        }
                    };
                }
                base.Dispatcher.BeginInvoke(method, DispatcherPriority.Background, new object[0]);
            }
        }

        private static void OnSearchTextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox) sender).OnSearchTextChanged(args);
        }

        private void OnSourceChanged(DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue is IEnumerable)
            {
                this.collectionViewSource = new CollectionViewSource();
                this.collectionViewSource.Source = args.NewValue;
                this.collectionViewSource.Filter += new FilterEventHandler(this.OnCollectionViewSourceFilter);
                this.PropagateGroupDescriptionsToCollectionView();
                this.View = this.collectionViewSource.View;
            }
            else
            {
                this.collectionViewSource = null;
                this.View = null;
            }
        }

        private static void OnSourceChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((SearchBox) sender).OnSourceChanged(args);
        }

        private void PropagateGroupDescriptionsToCollectionView()
        {
            if (this.collectionViewSource != null)
            {
                this.collectionViewSource.GroupDescriptions.Clear();
                foreach (GroupDescription description in this.GroupDescriptions)
                {
                    this.collectionViewSource.GroupDescriptions.Add(description);
                }
            }
        }

        private void PropagateResultGroupStyleToSearchList()
        {
            if (this.searchList != null)
            {
                this.searchList.GroupStyle.Clear();
                foreach (GroupStyle style in this.ResultGroupStyle)
                {
                    this.searchList.GroupStyle.Add(style);
                }
            }
        }

        public ObservableCollection<GroupDescription> GroupDescriptions
        {
            get
            {
                return this.groupDescriptions;
            }
        }

        public bool IsOpen
        {
            get
            {
                return (bool) base.GetValue(IsOpenProperty);
            }
            private set
            {
                base.SetValue(IsOpenProperty, value);
            }
        }

        public object ResultEmptyContent
        {
            get
            {
                return base.GetValue(ResultEmptyContentProperty);
            }
            set
            {
                base.SetValue(ResultEmptyContentProperty, value);
            }
        }

        public DataTemplate ResultEmptyContentTemplate
        {
            get
            {
                return (DataTemplate) base.GetValue(ResultEmptyContentTemplateProperty);
            }
            set
            {
                base.SetValue(ResultEmptyContentTemplateProperty, value);
            }
        }

        public ObservableCollection<GroupStyle> ResultGroupStyle
        {
            get
            {
                return this.resultGroupStyle;
            }
        }

        public Style ResultItemContainerStyle
        {
            get
            {
                return (Style) base.GetValue(ResultItemContainerStyleProperty);
            }
            set
            {
                base.SetValue(ResultItemContainerStyleProperty, value);
            }
        }

        public StyleSelector ResultItemContainerStyleSelector
        {
            get
            {
                return (StyleSelector) base.GetValue(ResultItemContainerStyleSelectorProperty);
            }
            set
            {
                base.SetValue(ResultItemContainerStyleSelectorProperty, value);
            }
        }

        public DataTemplate ResultItemTemplate
        {
            get
            {
                return (DataTemplate) base.GetValue(ResultItemTemplateProperty);
            }
            set
            {
                base.SetValue(ResultItemTemplateProperty, value);
            }
        }

        public Style ResultListBoxStyle
        {
            get
            {
                return (Style) base.GetValue(ResultListBoxStyleProperty);
            }
            set
            {
                base.SetValue(ResultListBoxStyleProperty, value);
            }
        }

        public string SearchText
        {
            get
            {
                return (string) base.GetValue(SearchTextProperty);
            }
            set
            {
                base.SetValue(SearchTextProperty, value);
            }
        }

        public IEnumerable Source
        {
            get
            {
                return (IEnumerable) base.GetValue(SourceProperty);
            }
            set
            {
                base.SetValue(SourceProperty, value);
            }
        }

        public ICollectionView View
        {
            get
            {
                return (ICollectionView) base.GetValue(ViewProperty);
            }
            private set
            {
                base.SetValue(ViewProperty, value);
            }
        }
    }
}

