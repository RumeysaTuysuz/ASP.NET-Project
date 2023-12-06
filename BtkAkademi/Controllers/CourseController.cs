using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi.Controllers
{
   public class CourseController : Controller
   {
      public IActionResult Index()
      {
         var model = Repository.Applications; 
         return View(model);
      }
      public IActionResult Apply()
      {
         return View();
      }
 
      [HttpPost]
      [ValidateAntiForgeryToken]     //güvenlik için, formda bir sahtecilik var mı , doğrulamak için kullanıyoruz.kullanıcıdan veri aldığımız ve veri tabanına eklediğimiz durumlarda kullanmamız önemlidir.
      public IActionResult Apply([FromForm]Candidate model)
      {

         if(Repository.Applications.Any(c => c.Email.Equals(model.Email)))       //aynı emaille birden fazla eğitime başvurulamaz ama null olabilir buna bir çözğm bul. 
         {
            ModelState.AddModelError("","There is already an application for you.");
         }

         if(ModelState.IsValid)     //alanların boş bırakılmamasını sağlıyor.
         {
         Repository.Add(model);
         return View("feedback" , model);  
         }
         return  View(); 

      }
   }
}