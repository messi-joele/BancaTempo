using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
     class Socio : IEquatable<Socio>
    {
        private string nome;
        private string cognome;
        private int debito;
        private double telefono;
        private bool segreteria;


        public Socio(string nome, string cognome, int debito, double telefono, bool segreteria)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.debito = debito;
            this.telefono = telefono;
            this.segreteria = segreteria;
            Prestazioni = new List<Prestazione>();
        }
        [JsonProperty]
        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nuovonome)
        {
            if (!String.IsNullOrWhiteSpace(nuovonome))
                cognome = nuovonome;
            else
                throw new Exception("Cognome non valido");
        }
        [JsonProperty]
        public string GetCognome()
        {
            return nome;
        }

        public void SetCognome(string nuovocognome)
        {
            if (!String.IsNullOrWhiteSpace(nuovocognome))
                cognome = nuovocognome;
            else
                throw new Exception("Cognome non valido");
        }
        [JsonProperty]
        public double GetNumero()
        {
            return GetNumero();
        }

        public void SetNumero(string nuovonumero)
        {
            if (!String.IsNullOrWhiteSpace(nuovonumero) && nuovonumero.Length == 10)
                telefono = nuovonumero;
            else
                throw new Exception("Numero di Telefono non valido");
        }
        [JsonProperty]
        public int GetDebito()
        {
            return debito;
        }

        public void SetDebito(int nuovodebito)
        {
            debito=nuovodebito;
        }
        [JsonProperty]
        public bool GetSegreteria()
        {
            return segreteria;
        }

        public void SetSegreteria(bool nuovasegreteria)
        {
            if (!String.IsNullOrWhiteSpace(nuovasegreteria.ToString()))
                segreteria = nuovasegreteria;
            else
                throw new Exception("Partecipazione alla segreteria non valida");
        }
        [JsonProperty]
        public List<Prestazione> Prestazioni { get; set; }
        public Socio()
        {
            cognome = "NoData";
            nome = "NoData";
            telefono = 1000000000;
            debito = 0;
            segreteria = false;
            Prestazioni = new List<Prestazione>();
        }

        public void AddPrest(Prestazione prestazione)
        {
            Prestazioni.Add(prestazione);
        }
        public int CalcDeb()
        {
            int oreErogate = 0;
            int oreRicevute = 0;

            foreach (Prestazione prestazione in Prestazioni)
            {
                if (prestazione.erogatore.Equals(this))
                {
                    oreErogate += prestazione.Ore;
                }
                else if (prestazione.ricevente.Equals(this))
                {
                    oreRicevute += prestazione.ore;
                }
            }

            this.debito = oreRicevute - oreErogate;
            return this.debito;
        }
        protected Socio(Socio other) : this(other.cognome, other.nome, other.telefono, other.debito, other.segreteria)
        {

        }
        public Socio Clone()
        {
            return new Socio(this);
        }
        public bool Equals(Socio u)
        {
            if (u == null) return false;

            if (this == u) return true;

            return (this.cognome == u.cognome && this.nome == u.nome);
        }

        public override string ToString()
        {
            return $"Socio: {cognome} {nome}; {telefono}, {debito}";
        }
    }

    
    

   
}
