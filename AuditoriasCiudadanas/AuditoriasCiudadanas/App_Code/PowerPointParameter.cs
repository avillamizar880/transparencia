using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PowerPointTemplates
{
    public class PowerPointParameter
    {

        #region Name
        /// <summary>
        /// Gets or sets the Name of this PowerPointParameter.
        /// </summary>
        public string Name { get; set; }
        #endregion


        #region Text
        /// <summary>
        /// Gets or sets the Text of this PowerPointParameter.
        /// </summary>
        public string Text { get; set; }
        #endregion


        #region Image
        /// <summary>
        /// Gets or sets the Image of this PowerPointParameter.
        /// </summary>
        public FileInfo Image { get; set; }
        #endregion


        #region Table
        /// <summary>
        /// Gets or sets the Table of this PowerPointParameter.
        /// </summary>
        public string Table { get; set; }
        #endregion
        

        #region Slide
        /// <summary>
        /// Gets or sets the Slide Number of this PowerPointParameter.
        /// </summary>
        public int Slide { get; set; }
        #endregion
    }
}
