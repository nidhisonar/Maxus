﻿using System.Web.Mvc;
using Maxis.Services.Abstract;
using Maxis.ViewModels;

namespace Maxis.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: USER/UsersList 
        public JsonResult UsersList()
        {
            return Json(_userService.GetAllUsers(), JsonRequestBehavior.AllowGet);
        }
        // GET: USER/Edit/5
        public JsonResult Edit(long id)
        {
            return Json(_userService.GetUserById(id), JsonRequestBehavior.AllowGet);
        }
        // PUT: USER/UpdateUser/
        [HttpPost]
        public void UpdateUser(EditUserViewModel editUserViewModel)
        {
            _userService.EditUser(editUserViewModel);
        }
    }
}
