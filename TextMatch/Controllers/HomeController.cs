using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextMatch.Models;
using TextMatch.Services;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        private ITextSearchService _textMatchService;

        public HomeController()
        {

        }

        public HomeController(ITextSearchService textMatchService)
        {
            if (textMatchService == null)
                throw new ArgumentNullException("textMatchService");

            _textMatchService = textMatchService;
        }

        protected ITextSearchService TextMatchService
        {
            get
            {
                _textMatchService = _textMatchService ?? new TextSearchService();
                return _textMatchService;
            }
            private set { _textMatchService = value; }
        }

        //
        // GET: /Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TextSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Result  = TextMatchService.GetAllMatchPos(
                model.LongText ?? string.Empty,
                model.SearchText ?? string.Empty);

            if (model.Result.Length > 0)
            {
                ViewBag.IsResultFound = true; 
            }
            else {
                ViewBag.IsResultFound = false;                 
            }

            return View(model);
        }
    }
}