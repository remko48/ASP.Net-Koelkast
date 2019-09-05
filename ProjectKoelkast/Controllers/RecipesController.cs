using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectKoelkast.Models;
using ProjectKoelkast.DataContext;
using System.IO;



namespace ProjectKoelkast.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IdentityDb _db = new IdentityDb();

        // GET: Recipes
        public ActionResult Recipes()
        {

            return View(_db.Recipes.ToList());
        }


        public ActionResult Get_Recipe(int Id)
        {
            var recipe = _db.Recipes.Find(Id);

            return View(recipe);
        }

        public ActionResult Add_Recipes()
        {
            Recipes recp = new Recipes();
            /*ViewBag.Ingredients = new SelectList(_db.Products(), "Value", "Text");*/

            return View();
        }

        [HttpPost]
        public ActionResult Add_Recipes(Recipes recipes, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                string filename = "";
                byte[] bytes;
                int BytestoRead;
                int numBytesRead;
                if (file != null)

                {

                    filename = Path.GetFileName(file.FileName);

                    bytes = new byte [file.ContentLength];

                    BytestoRead = (int)file.ContentLength;

                    numBytesRead = 0;

                    while (BytestoRead > 0)

                    {

                        int n = file.InputStream.Read(bytes, numBytesRead, BytestoRead);

                        if (n == 0) break;

                        numBytesRead += n;

                        BytestoRead -= n;

                    }

                    recipes.ImageUrl = bytes;

                }

                
                _db.Recipes.Add(recipes);
                _db.SaveChanges();
                return RedirectToAction("Recipes", "Recipes");
            }

            return View();
        }
        /*public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                StudentEntities db = new StudentEntities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(physicalPath);
                tblStudent student = new tblStudent();
                student.FirstName = Request.Form["firstname"];
                student.LastName = Request.Form["lastname"];
                student.ImageUrl = ImageName;
                db.tblStudents.Add(student);
                db.SaveChanges();

            }
            return RedirectToAction("../home/DisplayImage/");
        }
        public ActionResult DisplayImage()
        {
            return View();
        }*/
    }

}