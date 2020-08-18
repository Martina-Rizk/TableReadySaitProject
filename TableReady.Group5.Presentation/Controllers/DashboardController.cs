using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableReady.Group5.BLL;
using TableReady.Group5.Domain;
using TableReady.Group5.Presentation.Helper;

namespace TableReady.Group5.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RewardManager rewardsManager;
        public DashboardController()
        {
            rewardsManager = new RewardManager();
        }

        [HttpGet]
        public IActionResult RewardPage()
        {
            dynamic dynamicModel = new ExpandoObject();

            var customer = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "User");

            dynamicModel.ResturantGrid = rewardsManager.GetAllResturants();
            dynamicModel.RewardGrid = rewardsManager.GetAllRewards(customer.ID);

            return View(dynamicModel);
        }

        [HttpGet]
        public IActionResult RedirectToReview(int id)
        {
            HttpContext.Session.SetInt32("ResturantId", id);

            return View();
        }

        [HttpPost]
        public IActionResult RedirectToReview(Review review)
        {
            var Customer = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "User");

            var ResturantId = HttpContext.Session.GetInt32("ResturantId");

            var CustomerId = Customer.ID;
            var reviewValue = review.reviewValue;
            var resturantName = rewardsManager.GetSelectedResturantName(ResturantId);

            var result = rewardsManager.GetCustomerRewardModel(CustomerId, ResturantId);

            if (string.IsNullOrWhiteSpace(review.FromTableReady) && string.IsNullOrWhiteSpace(review.FromFacebook) && string.IsNullOrWhiteSpace(review.FromGoogle) && reviewValue == "-1")
                return RedirectToAction("RewardPage", "Dashboard");
            else if (result == null)
            {
                var discount = 0;
                var Checked = false;
                if (reviewValue == "1")
                {
                    discount += 10;
                    Checked = true;
                }
                else if (reviewValue == "0")
                    Checked = false;

                if (!string.IsNullOrWhiteSpace(review.FromTableReady))
                    discount += 5;

                if (!string.IsNullOrWhiteSpace(review.FromFacebook))
                    discount += 5;

                if (!string.IsNullOrWhiteSpace(review.FromGoogle))
                    discount += 5;

                Reward rewardModel = new Reward
                {
                    Points = discount,
                    CustomerID = CustomerId,
                    RestaurantID = ResturantId,
                    IsChecked = Checked
                };

                var AddedresultValue = rewardsManager.UpdateCustomerRewardModel(rewardModel);
                if (AddedresultValue != 0)
                    return RedirectToAction("RewardPage", "Dashboard");
                else
                    ViewBag.Msg = "Review Not Added";
            }
            else
            {
                if (reviewValue == "1")
                {
                    result.Points += 10;
                    result.IsChecked = true;
                }
                else if (reviewValue == "0")
                    result.IsChecked = false;

                if (!string.IsNullOrWhiteSpace(review.FromTableReady))
                    result.Points += 5;

                if (!string.IsNullOrWhiteSpace(review.FromFacebook))
                    result.Points += 5;

                if (!string.IsNullOrWhiteSpace(review.FromGoogle))
                    result.Points += 5;

                var updateResult = rewardsManager.UpdateCustomerRewardModel(result);
                if (updateResult != 0)
                    return RedirectToAction("RewardPage", "Dashboard");
                else
                    ViewBag.Msg = "Review Not Added";
            }

            return View();
        }
    }
}