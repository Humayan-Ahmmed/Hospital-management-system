using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Doctors247.Models;
using System.Data.Entity.Validation;

namespace Doctors247.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Hologin()
        {
            if (Session["username"] == null)
            {
                return Redirect("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Hologin(string cbutton)
        {

            if (cbutton == "Logout")
            {
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        public ActionResult HealthCards()
        {

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Doctor_registration()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]

        public ActionResult Doctor_registration(string username, string first_name, string last_name, string email, string password1,
            string contactNO, string speciality, string designation, string Address, string Fees)
        {

            String query = "insert Into d_registration(username, first_name, last_name, email," +
                    " pass,contactNO,speciality,Addresss,designation,Fees) " +
                    "values('" + username + "', '" + first_name + "', '" + last_name + "', " +
                    "'" + email + "', '" + password1 + "', '" + contactNO + "', '" + speciality + "'," +
                    " '" + designation + "', '" + Address + "', '" + Fees + "')";
            String mycon = "Data Source=DESKTOP-QVFT4VM\\SQLEXPRESS; Initial Catalog=Doctors247; Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            ViewBag.Message = "Registration Form Has Been Saved Successfully";
            return View();
        }

        //public ActionResult Doctor_registration(d_registration doc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (Doctors247EntitiesM db = new Doctors247EntitiesM())
        //        {
        //            d_registration rt = new d_registration();
        //            rt.username = doc.username;
        //            rt.first_name = doc.first_name;
        //            rt.last_name = doc.last_name;
        //            rt.contactNO = doc.contactNO;
        //            rt.email = doc.email;
        //            rt.speciality = doc.speciality;
        //            rt.designation = doc.designation;
        //            rt.Fees = doc.Fees;
        //            rt.Addresss = doc.Addresss;
        //            rt.pass = doc.pass;
        //            //rt.ConfirmPassword = doc.ConfirmPassword;
        //            db.d_registration.Add(rt);
        //            try
        //            {
        //                db.SaveChanges();
        //            }
        //            catch (DbEntityValidationException e)
        //            {
        //                Console.WriteLine(e);
        //            }

        //            return View();

        //            Response.Write("<script> alert('Data has been submitted succesfully')</script");


        //        }
        //    }
        //    return View();
        //}

        public ActionResult Patient_registration()
        {
            return View();
        }
        public ActionResult Patient_login()
        {
            return View();
        }

        public ActionResult Doctor_login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Doctor_login(string username, string password1)
        {
            String cpassword = "";
            String mycon = "Data Source=DESKTOP-QVFT4VM\\SQLEXPRESS; Initial Catalog=Doctors247; Integrated Security=true";
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select * from d_registration where username='" + username + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                cpassword = ds.Tables[0].Rows[0]["pass"].ToString();
                scon.Close();
                if (password1 == cpassword)
                {
                    Session["username"] = username;
                    return RedirectToAction("Hologin", "Home");
                }
                else
                {
                    ViewBag.loginresult = "Invalid Username or Password";
                    return View();
                }
            }
            else
            {
                ViewBag.loginresult = "Invalid Username or Password";
                return View();
            }


        }
        public ActionResult Doctors_dept()
        {
            if (Session["username"] == null)
            {
                return Redirect("Index");
            }
            return View();
        }

        public ActionResult Hospital()
        {
            if (Session["username"] == null)
            {
                return Redirect("Index");
            }
            String constring = "Data Source=DESKTOP-QVFT4VM\\SQLEXPRESS; Initial Catalog=Doctors247; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "GetHospital"; ;
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return View(dt);
        }
        public ActionResult SearchHospital()
        {
            ViewBag.searchresult = "";
            SearchHospital sd = new SearchHospital();
            sd.h_name = "";
            sd.location = "";
            sd.contact = "";
            sd.spec1 = "";
            sd.spec2 = "";
            sd.spec3 = "";
            return View(sd);

        }
        [HttpPost]
        public ActionResult SearchHospital(String h_name)
        {
            SearchHospital sd = new SearchHospital();
            String mycon = "Data Source=DESKTOP-QVFT4VM\\SQLEXPRESS; Initial Catalog=Doctors247; Integrated Security=True";
            String myquery = "Select * from hospital where h_name='" + h_name + "'";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.searchresult = "The desired Hospital info Has Been Found";
                sd.h_name = h_name;
                sd.location = ds.Tables[0].Rows[0]["location"].ToString();
                sd.contact = ds.Tables[0].Rows[0]["contact"].ToString();
                sd.spec1 = ds.Tables[0].Rows[0]["spec1"].ToString();
                sd.spec2 = ds.Tables[0].Rows[0]["spec2"].ToString();
                sd.spec3 = ds.Tables[0].Rows[0]["spec3"].ToString();

            }
            else
            {
                
                return Redirect("Hospital");
                ViewBag.searchresult = "The desired Hospital info Has Not Found";

            }
            con.Close();



            return View(sd);
        }
    


        public ActionResult Health_blog()
        {
            if (Session["username"] == null)
            {
                return Redirect("Index");
            }
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AddPost()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult Comments()
        {
            return View();
        }
        public ActionResult editPost()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult ViewPost()
        {
            return View();
        }
        public ActionResult editProfile()
        {
            return View();
        }
        public ActionResult editUser()
        {
            return View();
        }
        public ActionResult User()
        {
            return View();
        }
    }
}