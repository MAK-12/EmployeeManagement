using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;


namespace EmployeeManagementPortal.MVC.Controllers
{
    /// <summary>
    ///  Create and Edit Employee Roles and Change Employee Role rate per hour
    /// </summary>

    public class RoleController : Controller
    {
        private IRolesService rolesService;

        public RoleController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }
        // GET: RoleController
        public async Task<IActionResult> Index()
        {
            var roles = await this.rolesService.GetRoles();

            var role = roles.Select(r => new RoleViewModel()
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName,
                RoleDescription = r.RoleDescription,
                RatePerhour = r.RatePerhour,
            });
            return View(role);
        }

        private static RoleViewModel MapObjectsDTOtoViewModel(Roles dto)
        {
            return new RoleViewModel()
            {
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                RoleDescription = dto.RoleDescription,
                RatePerhour = dto.RatePerhour,
            };
        }
        private static Roles MapObjectsViewModeltoDTO(RoleViewModel roleViewModel)
        {
            return new Roles()
            {
                RoleId = roleViewModel.RoleId,
                RoleName = roleViewModel.RoleName,
                RoleDescription = roleViewModel.RoleDescription,
                RatePerhour = roleViewModel.RatePerhour,
            };
        }


        // GET: RoleController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var dto = await this.rolesService.GetRoleById(id);
            RoleViewModel roleViewModel = MapObjectsDTOtoViewModel(dto);
            return View(roleViewModel);
        }

        // GET: RoleController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var dto = await this.rolesService.GetRoleById(id);
            RoleViewModel roleViewModel = MapObjectsDTOtoViewModel(dto);
            return View(roleViewModel);
        }

        // GET: RoleController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: RoleController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await this.rolesService.DeleteRole(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
          
        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<ActionResult> CreateAsync(RoleViewModel roleViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await this.rolesService.CreateRole(MapObjectsViewModeltoDTO(roleViewModel));
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return View(ex.InnerException.Message);
                }
            }

            return View();
        }

        // POST: RoleController/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel roleViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await this.rolesService.UpdateRole(MapObjectsViewModeltoDTO(roleViewModel));
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        } 

        
    }
}
