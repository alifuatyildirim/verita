﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Verita.Common;

namespace AdminLTE.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public SidebarViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            //you can do the access rights checking here by using session, user, and/or filter parameter
            var sidebars = new List<SidebarMenu>();

            //if (((ClaimsPrincipal)User).GetUserProperty("AccessProfile").Contains("VES_008, Payroll"))
            //{
            //}

            sidebars.Add(ModuleHelper.AddHeader("MAIN NAVIGATION"));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Error, Tuple.Create(0, 0, 1)));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.About, Tuple.Create(0, 1, 0)));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Contact, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Product, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Category, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Page, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.HomePageSlider, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.HomePageContent, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.BasindaBiz, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Referanslar, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.BunlariBiliyorMusunuz, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.NedenVerita, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Hakkimizda, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.HakkimizdaTimeLine, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.MeyveliRehber, Tuple.Create(1, 0, 0)));
            sidebars.Add(ModuleHelper.AddTree("Account"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                //ModuleHelper.AddModule(ModuleHelper.Module.Login),
                ModuleHelper.AddModule(ModuleHelper.Module.Register, Tuple.Create(1, 1, 1)),
            };

            if (User.IsInRole("SuperAdmins"))
            {
                sidebars.Add(ModuleHelper.AddTree("Administration"));
                sidebars.Last().TreeChild = new List<SidebarMenu>()
                {
                    ModuleHelper.AddModule(ModuleHelper.Module.SuperAdmin),
                    ModuleHelper.AddModule(ModuleHelper.Module.Role),
                };
                //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.UserLogs));
            }

            return View(sidebars);
        }
    }
}
