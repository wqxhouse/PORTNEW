using System.Windows;
using System.Windows.Input;
using ActiproSoftware.Text;
using System;
using ActiproSoftware.Windows.Controls.SyntaxEditor;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using ActiproSoftware.Windows.Controls.Docking;
using GalaSoft.MvvmLight.Messaging;

namespace PORTAPP.WineJournal
{
    /// <summary>
    /// Description for JournalEditor.
    /// </summary>
    /// <summary>
	/// Represents a custom <see cref="DocumentWindow"/> implementation.
	/// </summary>
    public partial class JournalEditor
    {

        private int	documentIndex = 1;
		private TextWindow	primaryDocumentWindow;

        private JournalEditorVM editorVM;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainWindow</c> class.
		/// </summary>
		public JournalEditor() {
			InitializeComponent();

            editorVM = (JournalEditorVM)DataContext;

			// Create an initial document
            this.CreateTextDocumentWindow(null).Text = editorVM.Text;

        
        }

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Creates a new text <see cref="DocumentWindow"/>.
		/// </summary>
		/// <param name="filename">The filename to open; <c>null</c> to create a new document.</param>
		/// <returns>The <see cref="DocumentWindow"/> that was created.</returns>
		private TextWindow CreateTextDocumentWindow(string filename) {
			string title, text;
			if (filename != null) {
				// Open an existing document
				title = System.IO.Path.GetFileName(filename);
				text = File.ReadAllText(filename);
			}
			else {
				// Create a new document
				title = String.Format("Document{0}.txt", documentIndex);
				text = String.Format("Document {0} created at {1}.", documentIndex, DateTime.Now);
				documentIndex++;
			}

			// Create the document
			TextWindow documentWindow = new TextWindow();
			documentWindow.Description = "Text document";
			documentWindow.FileName = filename;
			documentWindow.ImageSource = new BitmapImage(new Uri("/Resources/Images/TextDocument16.png", UriKind.Relative));
			documentWindow.Title = title;
			documentWindow.Text = text;
			dockSite.DocumentWindows.Add(documentWindow);

			// Activate the document
			documentWindow.Activate();

			return documentWindow;
		}

		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnCascadeMenuItemClick(object sender, RoutedEventArgs e) {
			tabbedMdiHost.Cascade();
		}
		
		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnExitMenuItemClick(object sender, RoutedEventArgs e) {
			//this.Close();
		}
		
		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnNewFileMenuItemClick(object sender, RoutedEventArgs e) {
			// Create a new document window
			this.CreateTextDocumentWindow(null);
		}

		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnOpenFileMenuItemClick(object sender, RoutedEventArgs e) {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			if (dialog.ShowDialog() == true) {
				// Create a document window
				this.CreateTextDocumentWindow(dialog.FileName);
			}
		}

        private void OnGoBackHome(object sender, RoutedEventArgs e)
        {
        }

        private void OnSaveToDataBase(object sender, RoutedEventArgs e)
        {
        }
		
		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnTabbedMdiHostPrimaryWindowChanged(object sender, DockingWindowPropertyChangedRoutedEventArgs e) {
			this.PrimaryDocumentWindow = tabbedMdiHost.PrimaryWindow as TextWindow;
            
		}

		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnTileHorizontallyMenuItemClick(object sender, RoutedEventArgs e) {
			tabbedMdiHost.TileHorizontally();
		}

		/// <summary>
		/// Occurs when a menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="RoutedEventArgs"/> that contains the event data.</param>
		private void OnTileVerticallyMenuItemClick(object sender, RoutedEventArgs e) {
			tabbedMdiHost.TileVertically();
		}

		/// <summary>
		/// Occurs when the selection changes.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="EditorViewSelectionEventArgs"/> that contains the event data.</param>
		private void OnViewSelectionChanged(object sender, EditorViewSelectionEventArgs e) {
			// Quit if this event is not for the active view
			if (!e.View.IsActive)
				return;

			// Update line, col, and character display
			this.UpdateStatusBarTextLocation(e.CaretPosition.DisplayLine, e.CaretDisplayCharacterColumn, e.CaretPosition.DisplayCharacter);
		}

		/// <summary>
		/// Gets or sets the primary document window.
		/// </summary>
		/// <value>The primary document window.</value>
		private TextWindow PrimaryDocumentWindow {
			get {
				return primaryDocumentWindow;
			}
			set {
				if (primaryDocumentWindow == value)
					return;

				if (primaryDocumentWindow != null)
					primaryDocumentWindow.ViewSelectionChanged -= OnViewSelectionChanged;
				
				primaryDocumentWindow = value;

				if (primaryDocumentWindow != null) {
					primaryDocumentWindow.ViewSelectionChanged += OnViewSelectionChanged;
					messagePanel.Content = primaryDocumentWindow.FileName ?? "Ready";
					this.UpdateStatusBarTextLocation(primaryDocumentWindow.CaretPosition.DisplayLine, primaryDocumentWindow.CaretColumn, primaryDocumentWindow.CaretPosition.DisplayCharacter);
				}
				else {
					messagePanel.Content = "Ready";
					this.UpdateStatusBarTextLocation(null, null, null);
				}
			}
		}

		/// <summary>
		/// Updates line, col, and character display.
		/// </summary>
		/// <param name="line">The line value.</param>
		/// <param name="col">The column value.</param>
		/// <param name="character">The character value.</param>
		private void UpdateStatusBarTextLocation(int? line, int? col, int? character) {
			if (line.HasValue) {
				linePanel.Text = String.Format("Ln {0}", line);
				columnPanel.Text = String.Format("Col {0}", col);
				characterPanel.Text = String.Format("Ch {0}", character);
			}
			else {
				linePanel.Text = null;
				columnPanel.Text = null;
				characterPanel.Text = null;
			}
		}
		
	}
    
}