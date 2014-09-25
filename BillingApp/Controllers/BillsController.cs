﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BillingApp.Models;
using BillingApp.DAL;

namespace BillingApp.Controllers
{
    public class BillsController : Controller
    {
        private BillingContext db = new BillingContext();

        // GET: /Bills/
        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.RecieverCompany).Include(b => b.SenderCompany);
            return View(bills.ToList());
        }

        // GET: /Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill =
                db.Bills
                    .Include(m => m.SenderCompany)
                    .Include(m => m.RecieverCompany)
                    .SingleOrDefault(m => m.BillNumber == id);
                
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: /Bills/Create
        public ActionResult Create()
        {
            ViewBag.RecieverCompanyId = new SelectList(db.Companies, "Id", "Code");
            ViewBag.SenderCompanyId = new SelectList(db.Companies, "Id", "Code");
            return View();
        }

        // POST: /Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BillNumber,Location,DUR,ValidUntill,PaymentDue,ServiceDate,SenderCompanyId,RecieverCompanyId,OverallPrice,Notes")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecieverCompanyId = new SelectList(db.Companies, "Id", "Code", bill.RecieverCompanyId);
            ViewBag.SenderCompanyId = new SelectList(db.Companies, "Id", "Code", bill.SenderCompanyId);
            return View(bill);
        }

        // GET: /Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecieverCompanyId = new SelectList(db.Companies, "Id", "Code", bill.RecieverCompanyId);
            ViewBag.SenderCompanyId = new SelectList(db.Companies, "Id", "Code", bill.SenderCompanyId);
            return View(bill);
        }

        // POST: /Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BillNumber,Location,DUR,ValidUntill,PaymentDue,ServiceDate,SenderCompanyId,RecieverCompanyId,OverallPrice,Notes")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecieverCompanyId = new SelectList(db.Companies, "Id", "Code", bill.RecieverCompanyId);
            ViewBag.SenderCompanyId = new SelectList(db.Companies, "Id", "Code", bill.SenderCompanyId);
            return View(bill);
        }

        // GET: /Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: /Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
