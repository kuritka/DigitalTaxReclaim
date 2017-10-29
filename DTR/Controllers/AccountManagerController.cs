using AutoMapper;
using DTR.Data;
using DTR.Data.Entities;
using DTR.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DTR.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly IReclaimRepository _repository;
        private readonly IMapper _mapper;

        public AccountManagerController(IReclaimRepository reclaimRepository, IMapper mapper)
        {
            _repository = reclaimRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("AttachTrade")]
        public IActionResult Index()
        {
            var reclaims = _repository.GetAllReclaims();
            var resultsViewModels = reclaims.Select(d => _mapper.Map<Reclaim, AttachTradeDetailViewModel>(d)).ToList();
            return View(resultsViewModels);
        }
    }
}