﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMasomo
{
    public partial class PDFViewer : Form
    {
        public PDFViewer(string title)
        {
            InitializeComponent();
            this.Text = title;
            
        }

        public void LoadPDF(string path)
        {
            
            myReader.LoadFile(path);
        }

         ~PDFViewer()
        {

        }

         private void PDFReaderClosing(object sender, FormClosingEventArgs e)
         {
             myReader.Dispose();
             Application.Exit();
         }
    }
}
