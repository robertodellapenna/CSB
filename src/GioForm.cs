using CSB_Project.src.business;
using CSB_Project.src.presentation;
using CSB_Project.src.presentation.ItemCreatorPresenter;
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
        private CategorizableItemCreator cip;
        public GioForm()
        {
            InitializeComponent();
            //borderLabel1.BorderSize = 3;
            //borderLabel1.BackColor = Color.Green;
            //borderLabel1.TextColorHover = Color.Red;
            //borderLabel1.Text = "Hello";
            //borderLabel1.Font = new Font(FontFamily.GenericSansSerif, 20);
            //borderLabel1.Click += handler;
            //ICategoryCoordinator coor = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            //CategoryPicker cp = new CategoryPicker(coor.RootCategory, new Size(200, 100));
            //cp.Location = new Point(0, 0);
            //this.Controls.Add(cp);

            //cip = new CategorizableItemCreator();
            //Controls.Add(cip);

            //PictureBox pb = new PictureBox();
            //pb.Image = new Bitmap(Image.FromFile("../../Icon/remove.png"), new Size(16, 32));
            //Controls.Add(pb);
            //pb = new PictureBox();
            //pb.Location = new Point(100, 0);
            //pb.Image = new Bitmap(Image.FromFile("../../Icon/remove.png"), new Size(32, 32));
            //Controls.Add(pb);

            //CategoryPicker categoryPicker1 = new CategoryPicker();
            //CategoryPicker categoryPicker1 = new CategoryPicker(coor.RootCategory);
            //categoryPicker1.RootCategory = coor.RootCategory;
            //categoryPicker1.ItemToShow = 2;
            //Controls.Add(categoryPicker1);

            //categoryPicker1.Size = new Size(110, 50);
            //categoryPicker1.SetSize(2);
            //categoryPicker1.AutoSize = true;
            //categoryPicker1.Size = categoryPicker1.Controls[0].Size; 
            //MessageBox.Show("cp " + categoryPicker1.Height);

            //using (ServiceDialog sd = new ServiceDialog("Inserire parametri servizio"))
            //{
            //    if (sd.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show(sd.NameText);
            //        //serviceDescription = sd.Description;
            //        //servicePrice = sd.Price;
            //        //range = new DateRange(sd.Start, sd.End);
            //    }
            //    else
            //        return;
            //}

            //using (StringDialog sd = new StringDialog("Inserire parametri servizio"))
            //{
            //    if (sd.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show(sd.Response);
            //        //serviceDescription = sd.Description;
            //        //servicePrice = sd.Price;
            //        //range = new DateRange(sd.Start, sd.End);
            //    }
            //    else
            //        return;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cliked");
            //MessageBox.Show("C0 name " + cip.Controls[0].Name);
            //MessageBox.Show("C1 name " + cip.Controls[1].Name);
            //MessageBox.Show("Control Count " + cip.Controls[0].Controls.Count);
            //MessageBox.Show("CatControl Count " + cip.Controls[0].Controls.OfType<CategoryPicker>().Count());
            foreach (CategoryPicker c in cip.Controls[0].Controls.OfType<CategoryPicker>())
            {
                MessageBox.Show(c.SelectedCategory?.Name??"");
            }
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
