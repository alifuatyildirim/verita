﻿namespace Verita.Common
{
    /// <summary>
    /// This is where you customize the navigation sidebar
    /// </summary>
    public static class ModuleHelper
    {
        public enum Module
        {
            //Home,
            //About,
            //Contact,
            //Error,
            //Login,
            Register,
            SuperAdmin,
            Role,
            //UserLogs,
            Product,
            Category,
            Page,
            BasindaBiz,
            HomePageSlider,
            HomePageContent,
            Referanslar,
            NedenVerita,
            BunlariBiliyorMusunuz,
            Hakkimizda,
            HakkimizdaTimeLine,
            MeyveliRehber
        }

        public static SidebarMenu AddHeader(string name)
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Header,
                Name = name,
            };
        }

        public static SidebarMenu AddTree(string name, string iconClassName = "fa fa-link")
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Tree,
                IsActive = false,
                Name = name,
                IconClassName = iconClassName,
                URLPath = "#",
            };
        }

        public static SidebarMenu AddModule(Module module, Tuple<int, int, int> counter = null)
        {
            if (counter == null)
                counter = Tuple.Create(0, 0, 0);

            switch (module)
            {
                //case Module.Home:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "Home",
                //        IconClassName = "fa fa-home",
                //        URLPath = "/",
                //        LinkCounter = counter,
                //    };
                //case Module.Login:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "Login",
                //        IconClassName = "fa fa-sign-in-alt",
                //        URLPath = "/Account/Login",
                //        LinkCounter = counter,
                //    };
                case Module.Register:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Register",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/Account/Register",
                        LinkCounter = counter,
                    };

                case Module.Hakkimizda:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Hakkimizda",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/Hakkimizda/Index",
                        LinkCounter = counter,
                    };
                case Module.HakkimizdaTimeLine:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "HakkimizdaTimeLine",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/HakkimizdaTimeLine/Index",
                        LinkCounter = counter,
                    };
                case Module.BunlariBiliyorMusunuz:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "BunlariBiliyorMusunuz",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/BunlariBiliyorMusunuz/Index",
                        LinkCounter = counter,
                    };
                case Module.NedenVerita:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "NedenVerita",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/NedenVerita/Index",
                        LinkCounter = counter,
                    };
                //case Module.About:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "About",
                //        IconClassName = "fa fa-users",
                //        URLPath = "/Home/About",
                //        LinkCounter = counter,
                //    };
                //case Module.Contact:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "Contact",
                //        IconClassName = "fa fa-phone",
                //        URLPath = "/Home/Contact",
                //        LinkCounter = counter,
                //    };
                //case Module.Error:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "Error",
                //        IconClassName = "fa fa-exclamation-triangle",
                //        URLPath = "/Home/Error",
                //        LinkCounter = counter,
                //    };
                case Module.SuperAdmin:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "User",
                        IconClassName = "fa fa-users",
                        URLPath = "/SuperAdmin",
                        LinkCounter = counter,
                    };
                case Module.Role:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Role",
                        IconClassName = "fa fa-user-tag",
                        URLPath = "/Role",
                        LinkCounter = counter,
                    };
                //case Module.UserLogs:
                //    return new SidebarMenu
                //    {
                //        Type = SidebarMenuType.Link,
                //        Name = "UserLogs",
                //        IconClassName = "fa fa-history",
                //        URLPath = "/UserLogs",
                //        LinkCounter = counter,
                //    };
                case Module.Product:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Product",
                        IconClassName = "fa fa-history",
                        URLPath = "/Product/Index",
                        LinkCounter = counter,
                    };
                case Module.Category:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Category",
                        IconClassName = "fa fa-history",
                        URLPath = "/Category/Index",
                        LinkCounter = counter,
                    };
                case Module.MeyveliRehber:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "MeyveliRehber",
                        IconClassName = "fa fa-history",
                        URLPath = "/MeyveliRehber/Index",
                        LinkCounter = counter,
                    };
                case Module.Referanslar:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Referanslar",
                        IconClassName = "fa fa-history",
                        URLPath = "/Referanslar/Index",
                        LinkCounter = counter,
                    };
                case Module.HomePageSlider:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "HomePageSlider",
                        IconClassName = "fa fa-history",
                        URLPath = "/HomePageSlider/Index",
                        LinkCounter = counter,
                    };
                case Module.HomePageContent:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "HomePageContent",
                        IconClassName = "fa fa-history",
                        URLPath = "/HomePageContent/Index",
                        LinkCounter = counter,
                    };
                case Module.Page:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Page",
                        IconClassName = "fa fa-history",
                        URLPath = "/Page/Index",
                        LinkCounter = counter,
                    };
                case Module.BasindaBiz:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "BasindaBiz",
                        IconClassName = "fa fa-history",
                        URLPath = "/BasindaBiz/Index",
                        LinkCounter = counter,
                    };

                default:
                    break;
            }

            return null;
        }
    }
}
