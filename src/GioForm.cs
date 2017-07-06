using CSB_Project.src.business;
using CSB_Project.src.presentation;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src
{
    public partial class GioForm : Form
    {
        public GioForm()
        {
            InitializeComponent();
            //borderLabel1.BorderSize = 3;
            //borderLabel1.BackColor = Color.Green;
            //borderLabel1.TextColorHover = Color.Red;
            //borderLabel1.Text = "Hello";
            //borderLabel1.Font = new Font(FontFamily.GenericSansSerif, 20);
            //borderLabel1.Click += handler;
            ICategoryCoordinator coor = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            CategoryPicker cp = new CategoryPicker(coor.RootCategory, new Size(200, 100));
            cp.Location = new Point(0, 0);
            this.Controls.Add(cp);
            CategoryManagerView v = new CategoryManagerView();
            new CategoryManagerPresenter(v, coor.RootCategory);
            v.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //borderLabel1.BackColor = Color.FromArgb(new Random().Next() % 256, new Random().Next() % 256, new Random().Next() % 256);
        }

        private void handler(Object obj, EventArgs e)
        {
            //MessageBox.Show("cliccato");
        }

        private void categoryPicker1_Load(object sender, EventArgs e)
        {
            //categoryPicker1.Size = new Size(categoryPicker1.Controls[0].Width, 100);
            //MessageBox.Show("Dim UC " + categoryPicker1.Width);
            //MessageBox.Show("Dim UC In " + categoryPicker1.Controls[0].Width);
            //foreach (Control c in categoryPicker1.Controls)
            //    foreach (Control c1 in c.Controls)
            //        MessageBox.Show("Parent " + c + "\nName " + c1 + " count " + c1.Controls.Count);
        }

        private void categoryPicker1_Load_1(object sender, EventArgs e)
        {
            
            //categoryPicker1.Size = new Size(panel1.Size.Width, panel1.Size.Height);
        }
    }
}
