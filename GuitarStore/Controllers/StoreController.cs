using Microsoft.AspNetCore.Mvc;
using GuitarStore.DS.StoreServices;

namespace WebApplication1.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        
        public async Task<IActionResult> ItemsView()
        {
            var AllItems = await _storeService.GetAllItems();

            return View(AllItems);
        }
        
    }
}