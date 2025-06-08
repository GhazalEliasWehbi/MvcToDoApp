using Microsoft.AspNetCore.Mvc; 
using MvcTodoApp.Models; 
using System.Collections.Generic; 
using System.Linq; 
 
namespace MvcTodoApp.Controllers 
{ 
    public class HomeController : Controller 
    { 
        //  قائمة المحاكاة لقاعدة البيانات
        private static List<TaskItem> tasks = new List<TaskItem> 
        { 
            new TaskItem { Id = 1, Title = "MVC Design Pattern تدرب على ", IsComplete = false }, 
            new TaskItem { Id = 2, Title = "N-tier Architecture تدرب على ", IsComplete = false }, 
            new TaskItem { Id = 3, Title = "git تدرب على استخدام", IsComplete = false }, 
        }; 
 
        /// <summary> 
        /// يعرض القائمة الرئيسية للمهام
        /// </summary> 
        public IActionResult Index() 
        { 
            return View(tasks); 
        } 
 
        /// <summary> 
        /// إضافة مهمة جديدة
        /// </summary> 
        [HttpPost] 
        public IActionResult AddTask(string title) 
        { 
            if (!string.IsNullOrEmpty(title)) 
            { 
                int newId = tasks.Max(t => t.Id) + 1; 
                var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false }; 
                tasks.Add(newTask); 
            } 
            return RedirectToAction("Index"); 
        } 
 
        /// <summary> 
        /// تعيين مهمة كمكتملة
        /// </summary> 
        [HttpPost] 
        public IActionResult CompleteTask(int id) 
        { 
            var task = tasks.FirstOrDefault(t => t.Id == id); 
            if (task != null) 
                task.IsComplete = true; 
            return RedirectToAction("Index"); 
        } 
 
        /// <summary>
        /// /// تعديل عنوان المهمة
        /// </summary> 
        /// <param name="id"> معرف المهمة</param> 
        /// <param name="newTitle">العنوان الجديد</param> 
        [HttpPost] 
    public IActionResult EditTask(int id, string newTitle)
{
    // ابحث عن المهمة باستخدام id
    var task = tasks.FirstOrDefault(t => t.Id == id);

    // تأكد من ان المهمة موجودة و ان العنوان غير فارغ
    if (task != null && !string.IsNullOrEmpty(newTitle))
    {
        // عدل عنوان المهمة
        task.Title = newTitle;
    }

    return RedirectToAction("Index");
}
    } 
}