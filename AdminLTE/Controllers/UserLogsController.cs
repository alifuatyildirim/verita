﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Verita.Data;

namespace AdminLTE.Controllers
{
    [Authorize(Roles = "SuperAdmins")]
    public class UserLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_context.UserAuditEvents.ToList());
        }
    }
}
