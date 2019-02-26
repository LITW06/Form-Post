using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult List()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PplConStr);
            return View(mgr.GetPeople());
        }

        public ActionResult ShowAdd()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(Person person)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PplConStr);
            mgr.AddPerson(person);
            return Redirect("/people/list");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PplConStr);
            mgr.Delete(id);
            return Redirect("/people/list");
        }
    }

    //Create a page that displays a list of People (or whatever interests you).
    //On top of the page, have a link that says "Add Person". When this link
    //is clicked, the user should be taken to a page that has a form that 
    //has textboxes for firstname/lastname/age (or whatever thing you're doing).
    //Beneath that, there should be a submit button. When the button is clicked,
    //the person should get added to the database, and the user should be redirected
    //back to the list of all the people. 

    //Second Exercise:

    //Add a column to your table called "Delete". In each row of the table, there
    //should be a delete button, that when clicked, will delete that person from the
    //database, and redirect the user back to the page that shows a list of all people.
    //The way to achieve this is to embed each Delete button in a form that posts
    //to an Action on your controller that will delete that person. Inside that form,
    //also have a hidden input with the id of that person. Then, in your controller,
    //take that id in as a parameter, delete that person, and then redirect back to
    //the list page.
}