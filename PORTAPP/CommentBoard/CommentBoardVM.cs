using GalaSoft.MvvmLight;

namespace PORTAPP.CommentBoard
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CommentBoardVM : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CommentBoardVM class.
        /// </summary>
        public CommentBoardVM()
        {

        }

        public string Name
        {
            get { return "Comment Board"; }
        }
    }
}