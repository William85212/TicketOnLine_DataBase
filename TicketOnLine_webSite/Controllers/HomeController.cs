using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                    //_sessionTools.clientsWeb.

                    if (clients.IsAdmin)
                    {
                        _sessionTools.IsAdmin = true;
                    }

                    return RedirectToAction("Index");


                }



            }
            return View(vm);
        }

        #region Connection anciennement index
        public ActionResult Connection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Connection(ClientsViewModel vm)
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
                    //_sessionTools.clientsWeb.

                    if (clients.IsAdmin)
                    {
                        _sessionTools.IsAdmin = true;
                    }

                    return RedirectToAction("Index");


                }



            }
            return View(vm);
        }


        #endregion

        public ActionResult Index2()
        
        {
            List<EventWeb> l = ServicesEvent.Get().Result;
            int count = l.Count;
            List<EventWeb> nouveaute = new List<EventWeb>();
            for (int i = l.Count; i > l.Count-4; i--)
            {
                nouveaute.Add(l[i-1]);
            }
            return View(nouveaute);
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
        //[HttpGet]
        //public ActionResult AllEvent(EventWeb web)
        //{
        //    List<DateEventWeb> l = ServicesEvent.GetDate(web.Id).Result;
        //    return PartialView(l);

        //}
        [AccesAttribute]
        public ActionResult DetailsEvent(int id)
        {
            return View(ServicesEvent.Get(id).Result);
        }

        [AccesAttribute]
        public ActionResult DetailsEvent2(int id)   //test : mise en place de la vue de detail avec html float!!
        {      
            List<CommentaireWeb> l =  ServicesCommentaire.Get().Result;
            List<CommentaireWeb> lv = new List<CommentaireWeb>();

            foreach (CommentaireWeb item in l)
            {
                if (item.IdEvent == id)
                {
                    lv.Add(item);
                }
            }

            ViewBag.ListeMsg = lv;
            return View(ServicesEvent.Get(id).Result);
        }


        public ActionResult GetEnventByIdSalle(int id)
        {
            return View(ServicesEvent.GetEventByIdSalle(id).Result);
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
        public ActionResult Reservation()
        {
            return View();
        }

        public ActionResult Reservation2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reservation2(ReservationWeb web)
        {
            if (ModelState.IsValid)
            {
                web.IdClient = _sessionTools.clientsWeb.Id;
                web.IdEvent = _sessionTools.eventWeb.Id;
                web.PrixPlace = _sessionTools.eventWeb.Prix;
                //ServicesReservation.Post(web);  pas d' enregistrement en db mtn ajout au panier et 
                _sessionTools.AddReservation(web);
                // return RedirectToAction("index");
                return View("ContinuerAchat2");
            }
            else return View(web);
            
        }
       
        public ActionResult GetDate(int id)
        {
            return View(ServicesEvent.GetDate(id).Result);
        }

        public ActionResult GetInfoReservation(int id)
        {
            _sessionTools.eventWeb = ServicesEvent.Get(id).Result;

            List<infoReservationWeb> d = ServicesEvent.GetInfoReservation(id).Result;

            List<SelectListItem> selectList = new List<SelectListItem>();


            foreach (var item in d)
            {
                selectList.Add(new SelectListItem { Value = item.DateRepresentetion.ToString(), Text = item.DateRepresentetion.ToString() });
            }

            ViewBag.Select = selectList;
            return View();
            
        }

        public ActionResult GetInfoReservation2(int id)
        {
            _sessionTools.eventWeb = ServicesEvent.Get(id).Result;

            List<infoReservationWeb> d = ServicesEvent.GetInfoReservation(id).Result;

            List<SelectListItem> selectList = new List<SelectListItem>();


            foreach (var item in d)
            {
                selectList.Add(new SelectListItem { Value = item.DateRepresentetion.ToString(), Text = item.DateRepresentetion.ToString() });
            }

            ViewBag.Select = selectList;
            return View();

        }


        
        //public ActionResult Panier2()      (SAR)
        //{
        //    return View(_sessionTools.Reservation);
        //}

        public ActionResult ContinuerAchat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContinuerAchat(ContinuerAchat continuerAchat )
        {
            if (continuerAchat.go == true)
            {
                return RedirectToAction("AllEvent");
            }
            else return RedirectToAction("FinalisationReservation");
        }

        public ActionResult ContinuerAchat2()
        {
            return View();
        }






        #region test propgressBar
        public ActionResult _finalisationReservation()      //vue a ajouter en vue pattielle par la suite
        {
            return View();
        }

        public ActionResult FinalisationReservation1()
        {
            ViewBag.client = _sessionTools.clientsWeb;
            return View();
        }
        public ActionResult FinalisationReservation2()
        {
            ViewBag.reservation = _sessionTools.Reservation;
            return View();
        }
        public ActionResult FinalisationReservation3()
        {
            ViewBag.client = _sessionTools.clientsWeb;
            ViewBag.reservation = _sessionTools.Reservation;
            
            return View();
        }
        //[HttpPost]
        //public ActionResult FinalisationReservation3()
        //{
        //    return View(new ReservationWeb());
        //}
        #endregion




        #region Panier AddOneReservation RemoveOneReservation DeleteAllReservation
        public ActionResult Panier()
        {
            ViewBag.liste = _sessionTools.Reservation;
            return View(_sessionTools.Reservation);
        }
        public ActionResult AddOneReservation(ReservationWeb web)
        {
            _sessionTools.AddOneReservation(web.Id);
            return RedirectToAction("Panier");
        }
        public ActionResult RemoveOneReservation(ReservationWeb web)
        {
            _sessionTools.RemoveOneReservation(web.Id);
            return RedirectToAction("Panier");
        }

        public ActionResult RemoveAll()
        {
            _sessionTools.RemoveAllReservation();
            return RedirectToAction("Panier");
        }
        #endregion
    }
}
