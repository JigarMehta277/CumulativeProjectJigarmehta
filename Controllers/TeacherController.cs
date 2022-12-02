using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativeProjectJigarmehta.Models;

namespace CumulativeProjectJigarmehta.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This function returns list teachers
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <returns>list of Teachers</returns>
        //GET : /Teachers/List
        public ActionResult List(string SearchKey = null)
        {

            TeachersController controller = new TeachersController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }


        /// <summary>
        /// rThis function returns multiple details of teachers.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>details of NewTeacher</returns>
        //GET: /Teacher/Show/{id}

        public ActionResult Show(int id)
        {
            TeachersController controller = new TeachersController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeachersController controller = new TeachersController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeachersController controller = new TeachersController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New

        public ActionResult New()
        {

            return View();
        }

        //POST : /Teacher/Create
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {

            Debug.WriteLine("This works fine");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;

            TeachersController Controller = new TeachersController();
            Controller.AddTeacher(NewTeacher);
            return RedirectToAction("List");
        }
    }
}