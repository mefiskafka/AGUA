using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sifayco.Controllers
{
    public class ContratosController : ApiController
    {
        private SIFAYCOEntities db = new SIFAYCOEntities();

        // GET api/Contratos
        public IEnumerable<T_CONTRATOS> GetT_CONTRATOS()
        {
            var tcontratos = db.T_CONTRATOS.Include(t => t.CT_GIROS).Include(t => t.CT_TOMAS).Include(t => t.T_USUARIO_SERVICIO);
            return tcontratos.AsEnumerable();
        }

        // GET api/Contratos/5
        //public T_CONTRATOS GetT_CONTRATOS(long id)
        //{
        //    T_CONTRATOS t_contratos = db.T_CONTRATOS.Find(id);
        //    if (t_contratos == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return t_contratos;
        //}

        
        public HttpResponseMessage Get(int id)
        {

            var tContrato = db.T_CONTRATOS.Find(id);
            if (tContrato == null) return (new HttpResponseMessage(HttpStatusCode.NotFound));
            db.Entry(tContrato).Reference(la => la.CT_GIROS).Load();
            db.Entry(tContrato).Reference(la => la.CT_TOMAS).Load();
            db.Entry(tContrato).Reference(la => la.T_USUARIO_SERVICIO).Load(); 
            return (Request.CreateResponse(HttpStatusCode.OK, tContrato));
        }

        // PUT api/Contratos/5
        public HttpResponseMessage PutT_CONTRATOS(long id, T_CONTRATOS tcontratos)
        {
            if (ModelState.IsValid && id == tcontratos.ID_CONTRATO)
            {
                db.Entry(tcontratos).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Contratos
        public HttpResponseMessage PostT_CONTRATOS(T_CONTRATOS tcontratos)
        {
            if (ModelState.IsValid)
            {
                db.T_CONTRATOS.Add(tcontratos);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tcontratos);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tcontratos.ID_CONTRATO }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Contratos/5
        public HttpResponseMessage DeleteT_CONTRATOS(long id)
        {
            T_CONTRATOS tcontratos = db.T_CONTRATOS.Find(id);
            if (tcontratos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.T_CONTRATOS.Remove(tcontratos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tcontratos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}