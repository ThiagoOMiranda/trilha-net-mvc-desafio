using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trilha_net_mvc_desafio.Context;
using trilha_net_mvc_desafio.Models;

namespace trilha_net_mvc_desafio.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();

            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.Titulo = MaiorPrimeiraLetra(tarefa.Titulo);

                tarefa.Descricao = MaiorPrimeiraLetra(tarefa.Descricao);

                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        private string MaiorPrimeiraLetra(string palavra)
        {
            char[] letras = palavra.ToCharArray();
            letras[0] = char.ToUpper(letras[0]);
            return new string(letras);
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            return tarefa == null ? NotFound() : View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            if (tarefa.Titulo != null)
                tarefaBanco.Titulo = tarefa.Titulo;

            if (tarefa.Descricao != null)
                tarefaBanco.Descricao = tarefa.Descricao;

            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Prioridade = tarefa.Prioridade;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            return View(tarefa);
        }

        [HttpGet("Index")]
        public ViewResult Index(string sortOrder, string searchString, string searchDate, string searchPriority, string searchStatus)
        {
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.IdSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.Datetime = DateTime.UtcNow;

            var tarefaBanco = from s in _context.Tarefas
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                tarefaBanco = tarefaBanco.Where(s => s.Titulo.Contains(MaiorPrimeiraLetra(searchString)) || s.Descricao.Contains(MaiorPrimeiraLetra(searchString)));
            }

            var brCultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");

            if (!String.IsNullOrEmpty(searchDate))
            {
                // var parseData = DateTime.ParseExact(searchDate, "dd/MM/yyyy", brCultureInfo);
                var parseData = Convert.ToDateTime(searchDate, brCultureInfo);
                // var parseData = DateTime.Parse(searchDate);
                tarefaBanco = tarefaBanco.Where(s => s.Data.Date == parseData);
            }

            if (!String.IsNullOrEmpty(searchPriority))
            {
                tarefaBanco = tarefaBanco.Where(s => s.Prioridade == Enum.Parse<EnumPrioridadeTarefa>(searchPriority));
            }

            if (!String.IsNullOrEmpty(searchStatus))
            {
                tarefaBanco = tarefaBanco.Where(s => s.Status == Enum.Parse<EnumStatusTarefa>(searchStatus));
            }

            switch (sortOrder)
            {
                case "name_asc":
                    tarefaBanco = tarefaBanco.OrderBy(s => s.Titulo);
                    break;
                case "name_desc":
                    tarefaBanco = tarefaBanco.OrderByDescending(s => s.Titulo);
                    break;
                case "Date":
                    tarefaBanco = tarefaBanco.OrderBy(s => s.Data);
                    break;
                case "date_desc":
                    tarefaBanco = tarefaBanco.OrderByDescending(s => s.Data);
                    break;
                case "id_desc":
                    tarefaBanco = tarefaBanco.OrderByDescending(s => s.Id);
                    break;
                default:
                    tarefaBanco = tarefaBanco.OrderBy(s => s.Id);
                    break;
            }

            return View(tarefaBanco.ToList());
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            return tarefa == null ? RedirectToAction(nameof(Index)) : View(tarefa);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
