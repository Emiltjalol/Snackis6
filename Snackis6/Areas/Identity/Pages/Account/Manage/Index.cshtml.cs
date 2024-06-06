// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackis6.Areas.Identity.Data;

namespace Snackis6.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Snackis6User> _userManager;
        private readonly SignInManager<Snackis6User> _signInManager;

        public IndexModel(
            UserManager<Snackis6User> userManager,
            SignInManager<Snackis6User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public IFormFile ProfileImage { get; set; }
        public string ProfileImagePath { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(Snackis6User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };

            ProfileImagePath = user.ProfileImage;


        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            

            await LoadAsync(user);
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    if (ProfileImage != null)
        //    {
        //        var fileName = Path.GetRandomFileName() + Path.GetExtension(ProfileImage.FileName);
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userImages", fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await ProfileImage.CopyToAsync(stream);
        //        }

        //        // Assuming you have a field in Snackis6User for the profile image path
        //        user.ProfileImage = fileName;
        //        await _userManager.UpdateAsync(user);
        //    }

        //    if (Input.PhoneNumber != user.PhoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
        //        if (!setPhoneResult.Succeeded)
        //        {
        //            StatusMessage = "Unexpected error when trying to set phone number.";
        //            return RedirectToPage();
        //        }
        //    }

        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToPage();
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (ProfileImage != null)
            {
                var fileName = Path.GetRandomFileName() + Path.GetExtension(ProfileImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userImages", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(stream);
                }

                user.ProfileImage = fileName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

