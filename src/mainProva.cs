using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class mainProva
    {
        public static void Main(string[] args)
        {
            StructureManagerView view = new StructureManagerView();
            Application.Run(view);
        }
    }
}
