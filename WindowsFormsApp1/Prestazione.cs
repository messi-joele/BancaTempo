using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class Prestazione 
    {
        private string id;
        private Socio erogatore;
        private Socio ricevente;
        public int ore;
        public DateTime data;
        public string tipo;

        public Prestazione(string id, Socio erogatore, Socio ricevente, int ore, DateTime data, string tipo)
        {
            this.id = id;
            this.erogatore = erogatore;
            this.ricevente = ricevente;
            this.ore = ore;
            this.data = data;
            this.tipo = tipo;
        }
        

        public string GetId()
        {
            return id;
        }

        public void SetId(string newid)
        {
            if (!String.IsNullOrWhiteSpace(newid))
                id = newid;
            else
                throw new Exception("Id non valido");
        }

       
        public Socio GetEroga()
        {
            return erogatore;
        }


        public void SetEroga(Socio newerogatore)
        {
            if (newerogatore != null)
                erogatore = newerogatore;
            else
                throw new Exception("Erogatore non valido");
        }

        
        public Socio GetRice()
        {
            return ricevente;
        }


        public void SetRice(Socio newricevente)
        {
            if (newricevente != null)
                ricevente = newricevente;
            else
                throw new Exception("Erogatore non valido");
        }

        

        public int GetOre()
        {
            return ore;
        }

        public void SetOre(int newore)
        {
            if (newore > 0)//Prestazioni da min 1h
                ore = newore;
            else
                throw new Exception("Ore non valide");
        }

       
        public DateTime GetData()
        {
            return data;
        }

        public void SetData(DateTime newData)
        {
            if (newData != null)
                data = newData;
            else
                throw new Exception("Data non valida");
        }


        public string GetTipo()
        {
            return tipo;
        }

        public void SetTipo(string newtipo)
        {
            if (newtipo != null)
                tipo = newtipo;
            else
                throw new Exception("Tipo non valido");
        }

        protected Prestazione(Prestazione other) : this(other.id, other.erogatore, other.ricevente, other.ore, other.data, other.tipo)
        {
        }

        public Prestazione Clone()
        {
            return new Prestazione(this);
        }

        public bool Equals(Prestazione p)
        {
            if (p == null) return false;

            if (this == p) return true;

            return (this.id == p.id);
        }
        public override string ToString()
        {
            return $"Prestazione:{id} {erogatore}; {ricevente}; {ore}; {data}; {tipo}";
        }
    }
}
