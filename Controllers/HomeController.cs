using Microsoft.AspNetCore.Mvc; 
using MvcTodoApp.Models; 
using System.Collections.Generic; 
using System.Linq; 
 
namespace MvcTodoApp.Controllers 
{ 
    public class HomeController : Controller 
    { 
        //  )ةركاذلا يف( تانايبلا ةدعاقل ةاكاحم ةمئاق 
        private static List<TaskItem> tasks = new List<TaskItem> 
        { 
            new TaskItem { Id = 1, Title = "MVC Design Pattern تدرب على ", IsComplete = false }, 
            new TaskItem { Id = 2, Title = "N-tier Architecture تدرب على ", IsComplete = false }, 
            new TaskItem { Id = 3, Title = "git تدرب على استخدام", IsComplete = false }, 
        }; 
 
        /// <summary> 
        /// ماهملل ةيسيئرلا ةمئاقلا ضرعي. 
        /// </summary> 
        public IActionResult Index() 
        { 
            return View(tasks); 
        } 
 
        /// <summary> 
        /// ةديدج ةمهم ةفاضإ. 
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
        /// ةلمتكمك ةمهم نييعت. 
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
        /// /// ةمهملا ناونع ليدعت. 
        /// </summary> 
        /// <param name="id"> ةمهملا فرعم</param> 
        /// <param name="newTitle">ديدجلا ناونعلا</param> 
        [HttpPost] 
    public IActionResult EditTask(int id, string newTitle)
{
    // مادختساب ةمهملا نع ثحبا id
    var task = tasks.FirstOrDefault(t => t.Id == id);

    // نأو ةدوجوم ةمهملا نأ نم دكأت newTitle  غراف ريغ
    if (task != null && !string.IsNullOrEmpty(newTitle))
    {
        // ةمهملا ناونع لدع
        task.Title = newTitle;
    }

    return RedirectToAction("Index");
}
    } 
}