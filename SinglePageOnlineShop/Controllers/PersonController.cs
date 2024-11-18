
using Microsoft.AspNetCore.Mvc;
using SinglePageOnlineShop.ApplocationServices.Dtos;
using SinglePageOnlineShop.ApplocationServices.Frameworks.Contracts;

namespace OnlineShop.Controllers
{
    public class PersonController : Controller
    {
        //private readonly IPersonRepository _personRepository;

        //public PersonController(IPersonRepository personRepository)
        //{
        //    _personRepository = personRepository;
        //}

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        #region [- Index -]
        public async Task<IActionResult> Index()
        {

            //var dto = new GetPersonDto(); 
            //await _personService.GetPerson(dto); 
            //return View((dto); 
            var person = await _personService.GetAllPerson();
            return View(person); 
        }
        
        #endregion

        #region [- Create -]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto model)
        {
            if (ModelState.IsValid)
            {
                await _personService.PostPerson(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region [- Edit -]
        public async Task<IActionResult> Edit(Guid id)
        {
            // Fetch the existing person details (if needed, implement in service)
            var dto = new PutPersonDto { Id = id }; // Assuming you pass ID to service
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PutPersonDto model)
        {
            if (ModelState.IsValid)
            {
                await _personService.PutPerson(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region [- Delete -]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = new DeletePersonDto { Id = id };
            return View(dto); // Confirm delete action in the view
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DeletePersonDto model)
        {
            await _personService.DeletePerson(model);
            return RedirectToAction("Index");
        }
        #endregion

        #region [- Details -]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = new GetPersonDto { Id = id }; // Adjust as necessary
            await _personService.GetPerson(dto);
            return View(dto);
        }
        #endregion

        #region [- NewChanges -]
        //#region [- Index -]
        //public async Task<IActionResult> Index()
        //{
        //    // Assuming the GetPerson method retrieves all persons
        //    var dto = new GetPersonDto(); // Adjust parameters as needed
        //    await _personService.GetPerson(dto); // Logic to retrieve list from service
        //    return View(dto); // Pass the DTO to the view
        //}
        //#endregion

        //#region [- Create -]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(PostPersonDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _personService.PostPerson(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
        //#endregion

        //#region [- Edit -]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    // Fetch the existing person details (if needed, implement in service)
        //    var dto = new PutPersonDto { Id = id }; // Assuming you pass ID to service
        //    return View(dto);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, PutPersonDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _personService.PutPerson(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
        //#endregion

        //#region [- Delete -]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var dto = new DeletePersonDto { Id = id };
        //    return View(dto); // Confirm delete action in the view
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(DeletePersonDto model)
        //{
        //    await _personService.DeletePerson(model);
        //    return RedirectToAction("Index");
        //}
        //#endregion

        //#region [- Details -]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var dto = new GetPersonDto { Id = id }; // Adjust as necessary
        //    await _personService.GetPerson(dto);
        //    return View(dto);
        //}
        //#endregion
        #endregion

        #region [- OtherCode -]
        //private readonly IPersonRepository _personRepository;

        //public PersonController(IPersonRepository personRepository)
        //{
        //    _personRepository = personRepository;
        //}
        //public ActionResult Person()
        //{
        //    DtoGetCategory = new Dtos.Category.DtoGetCategory();
        //    return View(DtoGetCategory);
        //}

        //#region [- Index -]
        //public IActionResult Index()
        //{
        //    return View(_personRepository.Select());
        //}
        //#endregion

        //#region [- Create -]
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FirstName,LastName")] Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _personRepository.Insert(person);
        //        return RedirectToAction("Index");
        //    }
        //    return View(person);
        //}

        //#endregion

        //#region [- Edit -]

        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var person = await _personRepository.FindById(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(person);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName")] Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _personRepository.Update(person);
        //        return RedirectToAction("Index");
        //    }
        //    return View(person);
        //}

        //#endregion

        //#region [- Delete -]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _personRepository.FindById(id);

        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}

        //// POST: People/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(Person person)
        //{
        //    var p = await _personRepository.FindById(person.Id);
        //    await _personRepository.Delete(p);
        //    return RedirectToAction("Index");
        //}
        //#endregion

        //#region [- Details -]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _personRepository.FindById(id);

        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}
        //#endregion 
        #endregion


    }
}
