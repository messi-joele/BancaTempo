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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void Aggiungi()
        {

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

        private void add_Click(object sender, EventArgs e)
        {
            bool done = true;
            double newphone;
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                done = false;
                MessageBox.Show("Cognome non valido");
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                done = false;
                MessageBox.Show("Nome non valido");
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text) || textBox3.Text.Length != 10)
            {
                try
                {
                    newphone = double.Parse(textBox3.Text);
                }
                catch
                {
                    done = false;
                    MessageBox.Show("Telefono non valido");
                }
            }
            
            if (done)
            {
                Socio nuovo = new Socio(textBox2.Text, textBox1.Text,0, double.Parse(textBox3.Text), false);
                Aggiungi(nuovo);
                MessageBox.Show("Aggiunta eseguita con SUCCESSO");
            }
        }
        public static void Aggiungi(Socio nuovo)
        {
            var N = new FileStream(@"soci.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            N.Close();
            StreamReader sr = new StreamReader(@"soci.json");
            StreamWriter sw = new StreamWriter(@"./soci2.json");

            string line = "";
            int i = 0;

            while (!sr.EndOfStream || i != 1)
            {
                line = sr.ReadLine();

                if (line != null && i == 0 && line != "]") //controlla se è 0 in quanto se è 1 vuol dire che è già scritto
                {
                    sw.WriteLine(line);
                }
                else if (line == "]")
                {
                    sw.WriteLine(",");
                    //aggiunta classe jsonata
                    string jsonString = JsonConvert.SerializeObject(nuovo, Formatting.None);
                    sw.WriteLine(jsonString);
                    sw.WriteLine("]");
                    i = 1;
                }
            }
            sr.Close();
            sw.Close();

            System.IO.File.Delete(@"soci.json");
            System.IO.File.Move(@"./soci2.json", @"soci.json");
        }
    }
}
