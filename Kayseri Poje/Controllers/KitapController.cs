using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kayseri_Poje.Models;

namespace Kayseri_Poje.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKitap_KayseriEntities db = new DbKitap_KayseriEntities();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }

        public ActionResult KitapEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP t)
        {
            db.TBLKITAP.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var delete = db.TBLKITAP.Find(id);

            db.TBLKITAP.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var bul = db.TBLKITAP.Find(id);
            return View(bul);
        }

        [HttpPost]
        public ActionResult KitapGüncelle(TBLKITAP t)
        {
            var kitap= db.TBLKITAP.Find(t.KİTAPID);
            kitap.AD= t.AD;
            kitap.YAZAR= t.YAZAR;
            kitap.SAYFA= t.SAYFA;
            kitap.KATEDORI= t.KATEDORI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}