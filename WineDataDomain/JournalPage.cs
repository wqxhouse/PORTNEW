﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WineDataDomain
{
    public class JournalPage
    {
        public int JournalID { get; set; }

        /// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <value>The header.</value>
		public string Header {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>The image.</value>
		public ImageSource ImageSource {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the overlay bottom right.
		/// </summary>
		/// <value>The color of the overlay bottom right.</value>
		public Color OverlayBottomRightColor {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the overlay top left.
		/// </summary>
		/// <value>The color of the overlay top left.</value>
		public Color OverlayTopLeftColor {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public string Text {
			get;
			set;
		}

        public DateTime PostDate
        {
            get;
            set;
        }

        public int PageNumber
        {
            get;
            set;
        }
	}
    
}
