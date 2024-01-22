using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Verita.Contract.Models;

namespace AdminLTE.ViewComponents
{
    public class PageAlertViewComponent : ViewComponent
    {

        public PageAlertViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            List<Message> messages;
            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = new List<Message>(ViewBag.PageAlerts);
            }
            return View(messages);
        }
    }
}
