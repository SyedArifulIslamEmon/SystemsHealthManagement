using System;
using System.Web.Mvc;

namespace Integra.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new log4NetHandleError());
           // filters.Add(new HandleErrorAttribute());
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
        AllowMultiple = true)]
    public class log4NetHandleError : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            if (controller == null || filterContext.ExceptionHandled)
                return;
            Exception exception = filterContext.Exception;

            if (exception == null)
                return;

            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            HandleErrorInfo handleErrorInfo = new HandleErrorInfo(exception, (string)controllerName, (string)actionName);

            ViewDataDictionary<HandleErrorInfo> Model = new ViewDataDictionary<HandleErrorInfo>(handleErrorInfo);

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new PartialViewResult()
                {
                    ViewData = Model,
                    ViewName = "Erros"
                };
            }
            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewData = Model,
                    ViewName = "Erros"
                };
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
        }
    }
}