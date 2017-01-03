using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AuditoriasCiudadanas.PowerPointTemplates
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


    }
}
