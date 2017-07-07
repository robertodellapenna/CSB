using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.presentation
{
    public class SectorCreatorPresenter
    {
        public SectorCreatorPresenter(SectorCreator sc)
        {
            #region Precondizioni
            if (sc == null)
                throw new ArgumentNullException("itemPickerControl null");
            #endregion
            
        }
    }
}
