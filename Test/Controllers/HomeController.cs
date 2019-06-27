using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Data.SqlClient;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private TestEntities db = new TestEntities();
        public ActionResult Index()
        {
            ViewBag.Question1 = "Create PROCEDURE InsertCustomer @Firstname varchar(25), @Lastname varchar(25), @PhoneNumber varchar(15),   @EmailAddress varchar(25),  @CreatedDate DATETIME  AS BEGIN insert into Customer(Firstname, Lastname, PhoneNumber, EmailAddress, CreateDate) values(@Firstname, @Lastname, @PhoneNumber, @EmailAddress, @CreatedDate) END";
            ViewBag.Question2 = "SELECT t.ACCOUNT_NUMBER , MAX(t.Amount), CAST(t.Transaction_DATETIME AS DATE) AS DATE FROM IXF_ACCOUNT t INNER JOIN IXF_TRANSACTION_TYPE  a on t.ID = a.ID INNER JOIN IXF_TRANSACTION b  on a.ID = b.ID WHERE ACCOUNT_NUMBER IN(SELECT ACCOUNT_NUMBER FROM XF_TRANSACTION WHERE a.Description = 'ถอนเงิน' GROUP BY CAST(t.Transaction_DATETIME AS DATE), t.ACCOUNT_NUMBER)";
            var Answer2 = (from T in db.IXF_TRANSACTION
                           join A in db.IXF_ACCOUNT on T.AccountNumber equals A.ID
                           join S in db.IXF_TRANSACTION_TYPE on A.ID equals S.ID
                           where S.Description == "ถอนเงิน"
                           group T by
                           new { y = T.Transaction_DATETIME.Value.Year,m =T.Transaction_DATETIME.Value.Month,d = T.Transaction_DATETIME.Value.Day, T.AccountNumber } into g
                           select new
                           {
                               AccountNumber = g.Key.AccountNumber,
                               Amount = g.Max(m => m.Amount),
                               
                           }).ToList();
            ViewBag.Answer2 = Answer2;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer customer)
        {
            var firstname = new SqlParameter("@Firstname", customer.Firstname);
            var lastname = new SqlParameter("@Lastname", customer.Lastname);
            var phonenumber = new SqlParameter("@PhoneNumber", customer.PhoneNumber);
            var emailaddress = new SqlParameter("@EmailAddress", customer.EmailAddress);
            var CreateDate = new SqlParameter("@CreatedDate", DateTime.Now);
            ViewBag.Customer = db.Database.SqlQuery<CustomerView>("EXEC InsertCustomer @Firstname ,@Lastname , @PhoneNumber , @EmailAddress, @CreatedDate ", firstname, lastname, phonenumber, emailaddress, CreateDate).ToList();
            ViewBag.Msg = "Customer have been inserted";
            ViewBag.Question1 = "Create PROCEDURE InsertCustomer @Firstname varchar(25), @Lastname varchar(25), @PhoneNumber varchar(15),   @EmailAddress varchar(25),  @CreatedDate DATETIME  AS BEGIN insert into Customer(Firstname, Lastname, PhoneNumber, EmailAddress, CreateDate) values(@Firstname, @Lastname, @PhoneNumber, @EmailAddress, @CreatedDate) END";
            ViewBag.Question2 = "SELECT t.ACCOUNT_NUMBER , MAX(t.Amount), CAST(t.Transaction_DATETIME AS DATE) AS DATE FROM IXF_ACCOUNT t INNER JOIN IXF_TRANSACTION_TYPE  a on t.ID = a.ID INNER JOIN IXF_TRANSACTION b  on a.ID = b.ID WHERE ACCOUNT_NUMBER IN(SELECT ACCOUNT_NUMBER FROM XF_TRANSACTION WHERE a.Description = 'ถอนเงิน' GROUP BY CAST(t.Transaction_DATETIME AS DATE), t.ACCOUNT_NUMBER)";
         
            return View();
        }
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