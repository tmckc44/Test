using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private TestEntities db = new TestEntities();
        public ActionResult Index()
        {
            ViewBag.Question1 = "Create PROCEDURE InsertCustomer @Firstname varchar(25), @Lastname varchar(25), @PhoneNumber varchar(15),   @EmailAddress varchar(25),  @CreatedDate DATETIME  AS BEGIN insert into Customer(Firstname, Lastname, PhoneNumber, EmailAddress, CreateDate) values(@Firstname, @Lastname, @PhoneNumber, @EmailAddress, @CreatedDate) END";
            ViewBag.Question2 = "SELECT t.ACCOUNT_NUMBERFROM IXF_ACCOUNT tINNER JOIN IXF_TRANSACTION_TYPE  a    on t.ID = a.IDINNER JOIN IXF_TRANSACTION b   on a.ID = b.IDWHERE ID IN(SELECT MAX(AMOUNT) FROM XF_TRANSACTION GROUPBY DATE, ACCOUNTNUMBER)";
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Customer customer)
        //{
        //    var firstname = new SqlParameter("@Firstname", customer.firstname);
        //    var lastname = new SqlParameter("@Lastname", customer.lastname); 
        //    var phonenumber = new SqlParameter("@PhoneNumber", customer.phonenumber); 
        //    var emailaddress = new SqlParameter("@EmailAddress", customer.emailaddress);
        //    var CreateDate = new SqlParameter("@CreatedDate", DateTime.Now);
        //    ViewBag.BedSizes = db.Database.SqlQuery<CustomerView>("@Firstname ,@Lastname , @PhoneNumber , @@EmailAddress,@CreatedDate ", firstname,lastname,phonenumber,emailaddress,CreateDate).ToList();
        //    return View();
        //}
            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}