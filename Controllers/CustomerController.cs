using Customers_crud.DAL;
using Customers_crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Customers_crud.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CustomersData.customersList = _context.Customers.ToList();
            List<CustomerViewModel> customerVMList = new List<CustomerViewModel>();

            if (CustomersData.customersList != null)
            {

                foreach (var customer in CustomersData.customersList)
                {
                    CustomerViewModel customerVM = new CustomerViewModel()
                    {
                        Id = customer.Id,
                        Tz = customer.Tz,
                        FullName = customer.FullName,
                        Email = customer.Email,
                        BirthDate = customer.BirthDate,
                        Gender = customer.Gender,
                        Phone = customer.Phone
                    };
                    customerVMList.Add(customerVM);
                }
                return View(customerVMList);
            }

            return View(customerVMList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CustomerViewModel customerDataFromView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string CustomerTZ = customerDataFromView.Tz.PadLeft(9, '0');

                    if (CustomersData.customersList.Any(c => c.Tz == CustomerTZ))
                    {
                        TempData["ErrorMessage"] = "Customer already exists!";
                        return View();
                    }
                    else
                    {
                        Customer customerInfo = new Customer()
                        {
                            Tz = customerDataFromView.Tz.PadLeft(9, '0'),
                            FullName = customerDataFromView.FullName,
                            Email = customerDataFromView.Email,
                            BirthDate = customerDataFromView.BirthDate,
                            Gender = customerDataFromView.Gender,
                            Phone = customerDataFromView.Phone
                        };
                        _context.Customers.Add(customerInfo);
                        _context.SaveChanges();
                        TempData["successMessage"] = "Customer created successfully!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Customer data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var specificCustomer = CustomersData.customersList.SingleOrDefault(x => x.Id == Id);

                if (specificCustomer != null)
                {
                    var customerView = new CustomerViewModel()
                    {
                        Id = specificCustomer.Id,
                        Tz = specificCustomer.Tz,
                        FullName = specificCustomer.FullName,
                        Email = specificCustomer.Email,
                        BirthDate = specificCustomer.BirthDate,
                        Gender = specificCustomer.Gender,
                        Phone = specificCustomer.Phone
                    };

                    return View(customerView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Customer data is not available with id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerDataFromView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customerInfo = new Customer()
                    {
                        Id = customerDataFromView.Id,
                        Tz = customerDataFromView.Tz.PadLeft(9, '0'),
                        FullName = customerDataFromView.FullName,
                        Email = customerDataFromView.Email,
                        BirthDate = customerDataFromView.BirthDate,
                        Gender = customerDataFromView.Gender,
                        Phone = customerDataFromView.Phone
                    };

                    _context.Customers.Update(customerInfo);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Customer updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Model data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var specificCustomer = CustomersData.customersList.SingleOrDefault(x => x.Id == Id);

                if (specificCustomer != null)
                {
                    var customerView = new CustomerViewModel()
                    {
                        Id = specificCustomer.Id,
                        Tz = specificCustomer.Tz,
                        FullName = specificCustomer.FullName,
                        Email = specificCustomer.Email,
                        BirthDate = specificCustomer.BirthDate,
                        Gender = specificCustomer.Gender,
                        Phone = specificCustomer.Phone
                    };

                    return View(customerView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Customer data is not available with id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Delete(CustomerViewModel customerDataFromView)
        {
            try
            {
                var specificCustomer = CustomersData.customersList.SingleOrDefault(x => x.Id == customerDataFromView.Id);
                if (specificCustomer != null)

                {
                    _context.Customers.Remove(specificCustomer);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Customer deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = $"Customer data is not available with id: {customerDataFromView.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }


        }
    }
}
