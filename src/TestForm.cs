﻿using CSB_Project.src.presentation;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            new ItemPickerPresenter(itemPickerControl1);
        }
    }
}