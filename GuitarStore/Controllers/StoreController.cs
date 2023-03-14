using Microsoft.AspNetCore.Mvc;
using GuitarStore.DS.Services;

namespace WebApplication1.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreService _storeService;
        public StoreController(ILogger<StoreController> logger, IStoreService storeService)
        {
            _logger = logger;
            _storeService = storeService;
        }
        
        public async Task<IActionResult> ItemsView()
        {
            var AllItems = await _storeService.GetAllItems();

            return View(AllItems);
        }
        
    }
}