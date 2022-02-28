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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                //On récupère le client choisi dans la liste
                Club unClub = (Club)comboBox1.SelectedItem;
                tbx_adresse.Text = unClub.ClubRue;
                tbx_nom.Text = unClub.ClubNom;
                tbx_tel.Text = unClub.ClubTel;

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
            comboBox1.DataSource = cnx.Clubs.OrderBy(cli => cli.ClubNom).ToList();
            comboBox1.DisplayMember = "ClubNom";
            comboBox1.ValueMember = "ClubId";
        }

        private void btn_creer_Click(object sender, EventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
            Club newClub = new Club();
            newClub.ClubNom = tbx_nom.Text;
            newClub.ClubRue = tbx_adresse.Text;
            newClub.ClubTel = tbx_tel.Text;
            cnx.Clubs.Add(newClub);
            cnx.SaveChanges();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
            Club unClub = (Club)comboBox1.SelectedItem;
            Club cModif = cnx.Clubs.Find(unClub.ClubId);
            cModif.ClubNom = tbx_nom.Text;
            cModif.ClubRue = tbx_adresse.Text;
            cModif.ClubTel = tbx_tel.Text;
            cnx.Clubs.Update(cModif);
            cnx.SaveChanges();
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            bdpbaudoin2Context cnx = new bdpbaudoin2Context();
            Club unClub = (Club)comboBox1.SelectedItem;
            Club sClub = cnx.Clubs.Where(n => n.ClubId == unClub.ClubId).FirstOrDefault();
            cnx.Clubs.Remove(sClub);
            cnx.SaveChanges();
        }
    }
}
