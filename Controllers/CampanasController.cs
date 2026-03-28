using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        public List<Campana> ObtenerCampanas()
        {
            return new List<Campana>
            {
                new Campana {
                    Id = 1,
                    Nombre = "CyberWow Electro",
                    Categoria = "Electro",
                    Estado = "Vigente",
                    Canal = "Web",
                    Descuento = 30,
                    FechaInicio = new DateTime(2026,3,15),
                    FechaFin = new DateTime(2026,3,25),
                    Descripcion = "Ofertas en electrodomésticos"
                },
                new Campana {
                    Id = 2,
                    Nombre = "Renueva tu Hogar",
                    Categoria = "Hogar",
                    Estado = "Vigente",
                    Canal = "Tienda",
                    Descuento = 25,
                    FechaInicio = new DateTime(2026,3,1),
                    FechaFin = new DateTime(2026,4,1),
                    Descripcion = "Renovación del hogar"
                },
                new Campana {
                    Id = 3,
                    Nombre = "Fashion Week Lima",
                    Categoria = "Moda",
                    Estado = "Próxima",
                    Canal = "App",
                    Descuento = 40,
                    FechaInicio = new DateTime(2026,4,10),
                    FechaFin = new DateTime(2026,4,20),
                    Descripcion = "Moda exclusiva"
                },
                new Campana {
                    Id = 4,
                    Nombre = "Tech Days",
                    Categoria = "Tecnología",
                    Estado = "Próxima",
                    Canal = "Web",
                    Descuento = 35,
                    FechaInicio = new DateTime(2026,5,1),
                    FechaFin = new DateTime(2026,5,10),
                    Descripcion = "Tecnología en oferta"
                },
                new Campana {
                    Id = 5,
                    Nombre = "Liquidación Verano",
                    Categoria = "Moda",
                    Estado = "Finalizada",
                    Canal = "Tienda",
                    Descuento = 50,
                    FechaInicio = new DateTime(2026,1,1),
                    FechaFin = new DateTime(2026,1,15),
                    Descripcion = "Liquidación total"
                }
            };
        }

        // 🔥 INDEX CON FILTRO (CORRECTO)
        public IActionResult Index(string categoria, string estado)
        {
            var lista = ObtenerCampanas();

            if (!string.IsNullOrEmpty(categoria))
                lista = lista.Where(x => x.Categoria == categoria).ToList();

            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(x => x.Estado == estado).ToList();

            return View(lista);
        }

        public IActionResult Detalle(int id)
        {
            var campana = ObtenerCampanas().FirstOrDefault(x => x.Id == id);
            return View(campana);
        }

        public IActionResult Filtro()
        {
            return View(ObtenerCampanas());
        }

        public IActionResult Resumen()
        {
            var lista = ObtenerCampanas();

            ViewBag.Total = lista.Count;
            ViewBag.Vigentes = lista.Count(x => x.Estado == "Vigente");
            ViewBag.Proximas = lista.Count(x => x.Estado == "Próxima");
            ViewBag.Finalizadas = lista.Count(x => x.Estado == "Finalizada");

            return View();
        }
    }
}