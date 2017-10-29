using DTR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DTR.Data
{
    public class ReclaimSeeder
    {

        private readonly ReclaimContext _context;
        private readonly UserManager<Account> _userManager;

        public ReclaimSeeder(ReclaimContext context, UserManager<Account> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async  Task Seed()
        {
            _context.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("kuritka@gmail.com");
            if(user == null)
            {
                user = new Account()
                {
                    Email = "kuritka@gmail.com",
                    Name = "MichalK",
                    UserName = "kuritka@gmail.com"
                };
                var result = await _userManager.CreateAsync(user,".Hello123");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("cannot create master user");
                }
            }
            var newState = new ReclaimState() { Name = "New" };
            var attachedState = new ReclaimState() { Name = "AttachedTradeInformation" };
            if (!_context.ReclaimStates.Any())
            {
                _context.Add(newState);
                _context.Add(attachedState);
                _context.Add(new ReclaimState() { Name = "ReviewedByTeam" });
                _context.Add(new ReclaimState() { Name = "ApprovedByAccountManager" });
                _context.Add(new ReclaimState() { Name = "Rejected" });
            }


            var customer1 = new Account() { Name = "customer1" };
            var customer2 = new Account() { Name = "customer2" };
            var accountManager1 = new Account() { Name = "accountManager1" };
            var accountManager2 = new Account() { Name = "ccountManager2" };
            var teamMember1 = new Account() { Name = "teamMember1 " };
            var teamMember2 = new Account() { Name = "teamMember2" };

            //if (!_context.Accounts.Any())
            //{
            //    if (!_context.Accounts.Any())
            //    {
            //        _context.Add(customer1);
            //        _context.Add(customer2);
            //        _context.Add(accountManager1);
            //        _context.Add(accountManager2);
            //        _context.Add(teamMember1);
            //        _context.Add(teamMember2);
            //    }
            //}

            if (!_context.Reclaims.Any())
            {
                if (!_context.Reclaims.Any())
                {
                    _context.Add(new Reclaim() {  Product = "ProductA", Message = "Hello World", TradeInformation = 0, ReclaimState = attachedState, Created = DateTime.Now, CreatedBy = customer1});
                    _context.Add(new Reclaim() {  Product = "ProductB", Message = "Second Message", TradeInformation = 0, ReclaimState = attachedState, Created = DateTime.Now.AddDays(-1), CreatedBy = customer2 });

                }
            }
            _context.SaveChanges();
        }
    }
}
