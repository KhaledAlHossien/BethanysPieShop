﻿using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        public readonly IPieRepository _pieRepository;

        public readonly ICategoryRepository _categoryRepository;

        public PieController (IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Chees Cakes";
            //ViewBag.k = "kkkkkkkkk";
            //return View(_pieRepository.AllPies);

            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "All Pies");
            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
           var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
               
            return View(pie);




            }
    }
}
