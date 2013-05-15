using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ActiproSoftware.Windows.Controls.Docking;
using ActiproSoftware.Text;
using ActiproSoftware.Windows.Controls.SyntaxEditor;

namespace PORTAPP.WineJournal
{
    /// <summary>
    /// TextWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TextWindow : DocumentWindow
    {

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // OBJECT
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes an instance of the <c>TextDocumentWindow</c> class.
        /// </summary>
        public TextWindow()
        {
            InitializeComponent();

            // Register class command bindings
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnCloseExecuted));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, OnSaveExecuted));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUBLIC PROCEDURES
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the caret position.
        /// </summary>
        /// <value>The caret position.</value>
        public TextPosition CaretPosition
        {
            get
            {
                return editor.Caret.Position;
            }
        }

        /// <summary>
        /// Gets the caret column.
        /// </summary>
        /// <value>The caret column.</value>
        public int CaretColumn
        {
            get
            {
                return editor.Caret.DisplayCharacterColumn;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnCloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnSaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Save file here.");
        }

        /// <summary>
        /// Gets or sets the document text.
        /// </summary>
        /// <value>The document text.</value>
        public string Text
        {
            get
            {
                return editor.Document.CurrentSnapshot.Text;
            }
            set
            {
                editor.Document.SetText(value);
            }
        }

        /// <summary>
        /// Provides access to the selection changed event.
        /// </summary>
        public event EventHandler<EditorViewSelectionEventArgs> ViewSelectionChanged
        {
            add
            {
                editor.ViewSelectionChanged += value;
            }
            remove
            {
                editor.ViewSelectionChanged -= value;
            }
        }

    }
}
