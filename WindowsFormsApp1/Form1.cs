using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Socio> soci = new List<Socio>();
        public List<Prestazione> prestazioni = new List<Prestazione>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            UpdateUI();
        }

        private void LoadData()
        {
            // Caricare dati da file JSON
            if (File.Exists("soci.json"))
            {
                string sociJson = File.ReadAllText("soci.json");
                soci = JsonConvert.DeserializeObject<List<Socio>>(sociJson);
            }

            if (File.Exists("prestazioni.json"))
            {
                string prestazioniJson = File.ReadAllText("prestazioni.json");
                prestazioni = JsonConvert.DeserializeObject<List<Prestazione>>(prestazioniJson);
            }
        }

        private void SaveData()
        {
            // Salvare dati su file JSON
            string sociJson = JsonConvert.SerializeObject(soci);
            File.WriteAllText("soci.json", sociJson);

            string prestazioniJson = JsonConvert.SerializeObject(prestazioni);
            File.WriteAllText("prestazioni.json", prestazioniJson);
        }

        private void UpdateUI()
        {
            // Aggiornare la visualizzazione dei dati nell'interfaccia grafica
            listBox4.Items.Clear();
            foreach (Socio socio in soci)
            {
                listBox4.Items.Add($"{socio.Cognome}, {socio.Nome} - Tel: {socio.Telefono}");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Logica per produrre l'elenco dei soci con debito
            List<Socio> debitori = soci.Where(s => s.CalcDeb() > 0).ToList();

            listBox3.Items.Clear();
            foreach (Socio debitor in debitori)
            {
                listBox3.Items.Add($"{debitor.Cognome}, {debitor.Nome} | Debito: {debitor.Debito}");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Logica per visualizzare i soci della segreteria
            List<Socio> segreteriaSoci = soci.Where(s => s.Segreteria).ToList();

            listBox2.Items.Clear();
            foreach (Socio segreteriaSocio in segreteriaSoci)
            {
                listBox2.Items.Add($"{segreteriaSocio.Cognome}, {segreteriaSocio.Nome} - Tel: {segreteriaSocio.Telefono}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Logica per ordinare e visualizzare le prestazioni
            List<Prestazione> prestazioniOrdinate = prestazioni.OrderByDescending(p => p.GetOre()).ToList();

            listBox1.Items.Clear();
            foreach (Prestazione prestazione in prestazioniOrdinate)
            {
                listBox1.Items.Add($"{prestazione.GetEroga().Cognome}, {prestazione.GetEroga().Nome} -> {prestazione.GetRice().Cognome}, {prestazione.GetRice().Nome} - {prestazione.GetOre()} ore di {prestazione.GetTipo()}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
            UpdateUI();
        }
    }
}
