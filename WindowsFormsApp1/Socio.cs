using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
     public class Socio : IEquatable<Socio>
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
        public string Nome
        {
            get
            {
                return nome;
            }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    nome = value;
                else
                    throw new Exception("Nome non valido");
            }
        }
        [JsonProperty]
        public string Cognome
        {
            get
            {
                return cognome;
            }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    cognome = value;
                else
                    throw new Exception("Cognome non valido");
            }
        }

        [JsonProperty]
        public double Telefono
        {
            get
            {
                return telefono;
            }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value.ToString()) && value.ToString().Length == 10)
                    telefono = value;
                else
                    throw new Exception("Numero di Telefono non valido");
            }
        }

        [JsonProperty]
        public int Debito
        {
            get
            {
                return debito;
            }
            set
            {
                debito = value;
            }
        }
        [JsonProperty]
        public bool Segreteria
        {
            get
            {
                return segreteria;
            }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value.ToString()))
                    segreteria = value;
                else
                    throw new Exception("Partecipazione alla segreteria non valida");
            }
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
                if (prestazione.GetEroga().Equals(this))
                {
                    oreErogate += prestazione.ore;
                }
                else if (prestazione.GetRice().Equals(this))
                {
                    oreRicevute += prestazione.ore;
                }
            }

            this.debito = oreRicevute - oreErogate;
            return this.debito;
        }
        protected Socio(Socio other) : this(other.cognome, other.nome, other.debito, other.telefono, other.segreteria)
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
