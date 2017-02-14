using AutoMapper;
using System;
using System.Data.Entity.Core;
using System.Net;
using System.Web.Mvc;

namespace #namespace#.Controllers
{
    public class #pagename#Controller : JsonController
    {
        #region IoC
        private readonly I#pagename#Business #pagenamelowercase#Business;
        private readonly ISession sessionWeb;
        private readonly ILog log;

        public #pagename#Controller(I#pagename#Business #pagenamelowercase#Business, ISession sessionWeb, ILog log)
        {
            this.#pagenamelowercase#Business = #pagenamelowercase#Business;
            this.sessionWeb = sessionWeb;
            this.log = log;
        }

        #endregion

        #region View
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Api

        [HttpPost]
        [ModuleAuthorize(Permission.CreateOrUpdate)]
        public ActionResult Save(#pagename# #pagenamelowercase#)
        {
            try
            {                
                #pagenamelowercase#Business.Save(#pagenamelowercase#);

                log.Info("Preencher o log.");

                return Json(Mapper.Map<#pagename#, #pagename#ViewModel>(#pagenamelowercase#), JsonRequestBehavior.AllowGet);
                
            }
            catch (FluentValidation.ValidationException ex)
            {
                log.Warn(ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Errors, JsonRequestBehavior.AllowGet);
            }
            catch (ObjectNotFoundException ex)
            {
                log.Warn(ex);
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro ao salvar programa.", JsonRequestBehavior.AllowGet);
            }
        }

        [ModuleAuthorize(Permission.Delete)]
        public ActionResult Delete(long id)
        {
            try
            {
                var #pagenamelowercase# = #pagenamelowercase#Business.Queries.Get(id);

                #pagenamelowercase#Business.Delete(id);

                log.Info("Preencher o log");

                return Json("#pagenameptbr# excluído com sucesso.");
            }
            catch (ValidationException ex)
            {
                log.Warn(ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Errors, JsonRequestBehavior.AllowGet);
            }
            catch (ObjectNotFoundException ex)
            {
                log.Warn(ex);
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro ao excluir programa.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [ModuleAuthorize(Permission.Read)]
        public ActionResult Get(long id)
        {
            try
            {
                return Json(#pagenamelowercase#Business.Queries.Get(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro ao carregar #pagenameptbr#.", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}