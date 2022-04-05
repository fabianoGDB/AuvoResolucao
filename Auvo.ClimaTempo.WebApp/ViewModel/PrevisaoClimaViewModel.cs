using Auvo.ClimaTempo.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auvo.ClimaTempo.WebApp.ViewModel
{
    public class PrevisaoClimaViewModel
    {
        DatabaseContext ctx = new DatabaseContext();

        public PrevisaoClimaViewModel()
        {
            Cidades = CarregarCidades("");
        }

        public int Id { get; set; }
        public Decimal TemperaturaMaxima { get; set; }
        public Decimal TemperaturaMinima { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public int CidadeId { get; set; }
        public List<SelectListItem> Cidades { get; set; }
        public int EstadoId { get; set; }
        public List<SelectListItem> Estados { get; set; }


        #region metodos

        public List<SelectListItem> CarregarCidades(string nome)
        {
            var lista = new List<SelectListItem>();
            var cidades = ctx.Cidade.ToList();

            try
            {
                foreach(var item in cidades)
                {
                    var option = new SelectListItem()
                    {
                        Text = item.Nome,
                        Value = item.Nome,
                        Selected = (item.Nome == nome)
                    };

                    lista.Add(option);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return lista;
        }
        #endregion
    }
}