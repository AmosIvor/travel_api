﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using travel_api.Constants;
using travel_api.Helpers;
using travel_api.Models.Auths;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Services.Basics
{
    public class AuthRepo : IAuthRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthRepo(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AuthResponseVM> SignInAsync(UserLogin userLogin)
        {
            // check username
            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            // add city
            if (user.CityId != null)
            {
                var city = await _context.Cities.FindAsync(user.CityId);

                if (city != null)
                {
                    user.City = city;
                }
            }

            //check password

            var passwordValid = await _userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!passwordValid)
            {
                throw new KeyNotFoundException("Wrong password");
            }

            // role in token
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            // get token
            var jwtToken = AppUtils.GetToken(authClaims, _configuration);

            // auth response
            var authResponseVM = new AuthResponseVM
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                User = new UserVM()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    UserDescription = user.UserDescription,
                    Male = user.Male,
                    CityId = user.CityId,
                    City = _mapper.Map<CityBaseVM>(user.City),
                    Avatar = user.Avatar
                }
            };

            return authResponseVM;
        }

        public async Task<UserVM> SignUpAsync(UserRegister userRegister)
        {
            // Check User Exist
            var checkMail = await _userManager.FindByEmailAsync(userRegister.Email);

            if (checkMail != null)
            {
                throw new Exception("Email existed!");
            }

            var checkUserName = await _userManager.FindByNameAsync(userRegister.UserName);

            if (checkUserName != null)
            {
                throw new Exception("UserName existed");
            }


            var user = new User()
            {
                // default field
                Id = await AppUtils.GenerateUserID(_context),
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                PhoneNumber = userRegister.Phone,
                SecurityStamp = Guid.NewGuid().ToString(),

                // custom field
                Male = true,
                DateBirth = DateTime.MinValue,
                Avatar = AppConstant.Avatar,
                CityId = userRegister.CityId
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Check role exist
            var roleExist = await _roleManager.RoleExistsAsync(AppRole.CUSTOMER);

            if (!roleExist)
            {
                // it doesn't exist customer role => create
                var roleCustomer = new IdentityRole()
                {
                    Name = AppRole.CUSTOMER,
                    ConcurrencyStamp = "1",
                    NormalizedName = AppRole.CUSTOMER.ToUpper(),
                };

                await _roleManager.CreateAsync(roleCustomer);
            }

            await _userManager.AddToRoleAsync(user, AppRole.CUSTOMER);

            // Save changes
            await _context.SaveChangesAsync();

            // Map user to userVM
            var userVM = _mapper.Map<UserVM>(user);

            return userVM;
        }
    }
}
