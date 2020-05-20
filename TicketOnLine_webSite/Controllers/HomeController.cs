using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketOnLine_webSite.Infrastructure;
using TicketOnLine_webSite.Models;
using TicketOnLine_webSite.Services;
using TicketOnLine_webSite.Utils;
using TicketOnLine_webSite.Utils.Custom_attribute;
using TicketOnLine_webSite.ViewModel;

namespace TicketOnLine_webSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionTools _sessionTools;
        private readonly IHascMdp _mdp;

        public HomeController(ILogger<HomeController> logger, ISessionTools sessionTools, IHascMdp mdp) : base(sessionTools)
        {
            _logger = logger;
            _sessionTools = sessionTools;
            _mdp = mdp;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ClientsViewModel vm)
         {
            ClientsWeb clients = (from c in ServicesClient.Get().Result
                                  where c.Email.Equals(vm.Clients.Email)
                                  select c).FirstOrDefault();
            if (ModelState.IsValid)
            {
                
                    if (clients is null)
                    {
                        ViewBag.ErrorInscription = "Veuillez vous inscrire avant de vous connecter!!";
                        return View(vm);
                    }

                    #region Hasc
                    
                    string MdpH = _mdp.HashMdp(vm.Clients.Password);
                    #endregion
                    if (MdpH != clients.Password)
                    {
                        ViewBag.ErrorMdp = "Mot de passe invalide!!";
                        return View(vm);
                    }
                    else
                    {
                        vm.Authentifie = true;
                        ViewBag.Connecter = "Bienvenue " + clients.Nom + " !!!";
                        _sessionTools.clientsWeb = clients;
                       
                        if (clients.IsAdmin)
                        {
                            _sessionTools.IsAdmin = true;
                        }

                        return RedirectToAction("GetAction");
                        

                    }
                
                
                
            }
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        #region Client
        public ActionResult GetAction()
        {
            ViewBag.msg = _sessionTools.Message;
            return View(ServicesClient.Get().Result);
            

        }
        [AccesAttribute]
        public ActionResult GetOne(int id)
        {
            return View(ServicesClient.Get(id).Result);
        }

       


        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(ServicesClient.Get(id).Result);
        }
        public ActionResult Update(ClientsWeb web)
        {
            if (ModelState.IsValid)
            {
                ServicesClient.Update(web);
                return Redirect("GetAction");
            }
            return View(web);
        }




        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(ClientsWeb web)
        {
            ClientsWeb clientsExist = (from c in ServicesClient.Get().Result
                                       where c.Email.Equals(web.Email)
                                       select c).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (clientsExist is null)
                {
                    string mpd = _mdp.HashMdp(web.Password);
                    web.Password = mpd;
                    ServicesClient.Post(web);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.ErrorEmail = "l'adresse email est déja utilisé";
                    return View(web);
                }
             
                
            }
            return View(web);
        }



        public ActionResult Delete(int id)
        {
            ServicesClient.Delete(id);
            return Redirect("GetAction");
        }

        #endregion



        #region Event 
        
        public ActionResult GetEvent(int id)
        {
            return View(ServicesEvent.Get(id).Result);
        }
        public ActionResult AllEvent()
        {
            return View(ServicesEvent.Get().Result);
        }

        [AccesAttribute]
        public ActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEvent(EventWeb web)
        {
            if (ModelState.IsValid)
            {
                ServicesEvent.Post(web);
                Redirect("GetAllEvent");
            }
            return View(web);
        }
        [AccesAttribute]
        [HttpGet]
        private ActionResult UpdateEvent(int id)
        {
            return View(ServicesEvent.Get(id));
        }
        private ActionResult UpdateEvent(EventWeb web)
        {
            if (ModelState.IsValid)
            {
                ServicesEvent.Update(web);
                Redirect("/");
            }
            return View();
        }

        [AccesAttribute]
        public ActionResult DeleteEvent(int id)
        {
            ServicesEvent.Delete(id);
            return Redirect("GetAllEvent");
        }

        [AccesAttribute]
        public ActionResult Ou(RechercheViewModel rechercheView)
        {
            if(!string.IsNullOrWhiteSpace(rechercheView.Search))
            {
                rechercheView.SearchResult = ServicesEvent.Get().Result.Where(r => r.NomSpectacle.IndexOf(rechercheView.Search, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }
            else
            {
                rechercheView.SearchResult = new List<EventWeb>();
            }
            return View(rechercheView);
        }
        #endregion

        #region test Ajax

        public ActionResult Recherche(RechercheViewModel rechercheView)
        {
            return View(rechercheView);
        }
        public ActionResult ResultatRecherche(RechercheViewModel rechercheView)
        {
            if (!string.IsNullOrWhiteSpace(rechercheView.Search))
            {
                rechercheView.SearchResult = ServicesEvent.Get().Result.Where(r => r.NomSpectacle.IndexOf(rechercheView.Search, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }
            else rechercheView.SearchResult = new List<EventWeb>();
            return PartialView(rechercheView);
        }



        #endregion

        [AccesAttribute]
        public ActionResult LogOut()
        {
            _sessionTools.Abandon();
            return RedirectToAction("index");
        }

        #region salle


        public ActionResult AfficherSalle()
        {
            return View(ServicesSalle.Get().Result);
        }


        public ActionResult AfficherSalle2()
        {
            return View(ServicesSalle.Get().Result);
        }
        #endregion
        [AccesAttribute]
        public ActionResult Reservation(int id)
        {
            return View();
        }

        public ActionResult Reservation2(int id)
        {
            return View();
        }
    }
}
