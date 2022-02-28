using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using triathletes.Models;

namespace triathletes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
            dataGridView1.DataSource = cnx.Clubs.ToList();
        }
    }
}
