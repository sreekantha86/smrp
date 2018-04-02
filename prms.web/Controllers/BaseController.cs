using prms.web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prms.web.Controllers
{
    [AuthorizeUser]
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            return base.BeginExecuteCore(callback, state);
        }
        public int UserID
        {
            get
            {
                HttpCookie usr = (HttpCookie)Session["user"];
                int Id = Convert.ToInt32(usr["UserId"]);
                return Id;
            }
            set
            {
            }
        }
        public string UserName
        {
            get
            {
                HttpCookie usr = (HttpCookie)Session["user"];
                return usr["UserName"].ToString();
            }
            set
            {

            }
        }
        public int OrganizationId
        {
            get
            {
                HttpCookie usr = (HttpCookie)Session["user"];
                int Id = Convert.ToInt32(usr["Organization"]);
                return Id;
            }
            set
            {

            }
        }
        //public DateTime FYStartDate
        //{
        //    get
        //    {
        //        UserRepository repo = new UserRepository();
        //        return repo.GetFinancialYearStartDate(UserID, OrganizationId);
        //    }
        //    set
        //    {

        //    }
        //}
        //public DateTime FYEndDate
        //{
        //    get
        //    {
        //        UserRepository repo = new UserRepository();
        //        return repo.GetFinancialYearEndDate(UserID, OrganizationId);
        //    }
        //    set
        //    {

        //    }
        //}
    }
}