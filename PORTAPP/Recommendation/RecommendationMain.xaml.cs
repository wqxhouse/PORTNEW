using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows;
using System.Linq;
using System;

namespace PORTAPP.Recommendation
{
    /// <summary>
    /// Description for RecommendationMain.
    /// </summary>
    public partial class RecommendationMain
    {

        private readonly RecommendationMainVM recVM;
        private readonly RecWines firstItem;

        /// <summary>
        /// Initializes a new instance of the RecommendationMain class.
        /// </summary>
        public RecommendationMain()
        {
            InitializeComponent();

            //set initial tile state as large
            recVM = (RecommendationMainVM)DataContext;
            firstItem = recVM.RecItems.FirstOrDefault();

            this.tileView.ItemContainerGenerator.StatusChanged += this.ItemContainerGenerator_StatusChanged;
        }

        void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            var generator = sender as System.Windows.Controls.ItemContainerGenerator;
            if (generator != null && generator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                this.tileView.MaximizeMode = TileViewMaximizeMode.One;
            }
        }


        private void tileView1_TileStateChanged(object sender, RadRoutedEventArgs e)
        {
            
            RadTileViewItem item = e.OriginalSource as RadTileViewItem;
            if (item != null)
            {
                RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
                if (fluid != null)
                {
                    

                    switch (item.TileState)
                    {
                        case TileViewItemState.Maximized:
                            fluid.State = FluidContentControlState.Large;
                            break;
                        case TileViewItemState.Minimized:
                            fluid.State = FluidContentControlState.Normal;
                            break;
                        case TileViewItemState.Restored:
                            fluid.State = FluidContentControlState.Normal;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    item.Loaded += new RoutedEventHandler(item_Loaded);
                }

            }
        }

        private void item_Loaded(object sender, RoutedEventArgs e)
        {
            RadTileViewItem item = (RadTileViewItem)sender;
            item.Loaded -= new RoutedEventHandler(item_Loaded);
            RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
            if (fluid != null)
            {
                if (item.TileState == TileViewItemState.Maximized)
                {
                    fluid.State = FluidContentControlState.Large;
                }
            }
        }
    }
}