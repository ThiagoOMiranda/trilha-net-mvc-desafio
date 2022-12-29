using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trilha_net_mvc_desafio.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public EnumPrioridadeTarefa Prioridade { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Data { get; set; }

        public EnumStatusTarefa Status { get; set; }
    }
}