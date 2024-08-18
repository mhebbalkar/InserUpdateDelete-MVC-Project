using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MachinePratice.Models;
using System.Web.Mvc.Ajax;



namespace MachinePratice.Controllers
{
    public class StudentController : Controller
    {
        string connectionStrings = @"Data Source=DESKTOP-CELUQR8\SQLEXPRESS; Database=Student_Db; Integrated Security=true";
        [HttpGet]
        // GET: Student
        public ActionResult Index()
        {
            DataTable dttblStudent = new DataTable();
            using (SqlConnection SqlCon = new SqlConnection(connectionStrings))
            {
                SqlCon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Student", SqlCon);
                sqlDataAdapter.Fill(dttblStudent);
            }

            return View(dttblStudent);
        }

        [HttpGet]
        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (SqlConnection SqlCon = new SqlConnection(connectionStrings))
            {
                SqlCon.Open();
                string query = "Insert into  Student values(@Name,@Email,@Address) ";
                SqlCommand sqlCmd = new SqlCommand(query, SqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", student.Name);
                sqlCmd.Parameters.AddWithValue("@Email", student.Email);
                sqlCmd.Parameters.AddWithValue("@Address", student.Address);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();    
            DataTable dttblStudent = new DataTable();
            using (SqlConnection SqlCon = new SqlConnection(connectionStrings))
            {
                SqlCon.Open();
                string query = "Select * from Student where StudentId = @StudentId";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, SqlCon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@StudentId", id);
                sqlDataAdapter.Fill(dttblStudent);

            }
            if(dttblStudent.Rows.Count ==1)
            {
                student.StudentId = Convert.ToInt32(dttblStudent.Rows[0][0].ToString());
                student.Name = dttblStudent.Rows[0][1].ToString();
                student.Email = dttblStudent.Rows[0][2].ToString();
                student.Address = dttblStudent.Rows[0][3].ToString();
                return View(student);

            }
            else
            return RedirectToAction("Index");
                
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            using (SqlConnection SqlCon = new SqlConnection(connectionStrings))
            {
                SqlCon.Open();
                string query = "Update Student set Name=@Name, Email=@EMail , Address=@Address where StudentId=@StudentId";
                SqlCommand sqlCmd = new SqlCommand(query, SqlCon);
                sqlCmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                sqlCmd.Parameters.AddWithValue("@Name", student.Name);
                sqlCmd.Parameters.AddWithValue("@Email", student.Email);
                sqlCmd.Parameters.AddWithValue("@Address", student.Address);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {


            using (SqlConnection SqlCon = new SqlConnection(connectionStrings))
            {
                SqlCon.Open();
                string query = "Delete from student where StudentId=@StudentId";
                SqlCommand sqlCmd = new SqlCommand(query, SqlCon);
                sqlCmd.Parameters.AddWithValue("@StudentId", id);
                
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

   
       
   
    }
}



