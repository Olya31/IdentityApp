﻿using IdentityApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApplication.Controllers
{
    [Authorize]
    public sealed class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpPost]
        public async Task<ActionResult> Delete(IEnumerable<Guid> selectedObjects)
        {
            try
            {
                foreach (var guid in selectedObjects)
                {
                    var user = await _userManager.FindByIdAsync(guid.ToString());
                    await _userManager.DeleteAsync(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult> Lock(IEnumerable<Guid> selectedObjects)
        {
            var isRedirect = false;

            try
            {
                foreach (var guid in selectedObjects)
                {
                    var user = await _userManager.FindByIdAsync(guid.ToString());

                    if (user != null)
                    {
                        user.IsLock = true;

                        await _userManager.UpdateAsync(user);

                        if (string.Equals(this.User.Identity.Name, user.UserName, StringComparison.OrdinalIgnoreCase))
                        {
                            isRedirect = true;
                        }
                    }
                }

                if (isRedirect)
                {
                    await _signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(new { isRedirectToLogin = isRedirect });
        }

        [HttpPost]
        public async Task<ActionResult> UnLock(IEnumerable<Guid> selectedObjects)
        {
            try
            {
                await UnLockProcessingAsync(selectedObjects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(true);
        }

        private async Task UnLockProcessingAsync(IEnumerable<Guid> selectedObjects)
        {
            foreach (Guid guid in selectedObjects)
            {
                var user = await _userManager.FindByIdAsync(guid.ToString());

                if (user != null)
                {
                    user.IsLock = false;
                    await _userManager.UpdateAsync(user);
                }
            }
        }
    }
}
