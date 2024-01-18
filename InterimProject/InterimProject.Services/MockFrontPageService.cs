using InterimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class MockFrontPageService : IFrontPageRepository
    {
        public FrontPageData GetFrontPageData()
        {
            var fpd = new FrontPageData()
            {
                Homedata2 = "Hungry?!",
                Homedata21 = "Good, we are here to serve you",
                Homedata3 = "STAY IN",
                Homedata31 = "We've got free Delivery",
                HomeImageUrl1 = "/images/home1.jpg",
                HomeImageUrl2 = "/images/home2.jpg",
                HomeImageUrl3 = "/images/home3.jpg",
                FoodSectionTitle = "Trending Results For U!!!",
                FoodImageUrl1 = "images/fchicken.jpg",
                food1 = "10% OFF",
                price1 = "order for Rs.100",
                FoodImageUrl2 = "images/ctpizza.jpg",
                food2 = "25% OFF",
                price2 = "order for Rs.399",
                FoodImageUrl3 = "images/cbiryani.jpg",
                food3 = "20% OFF",
                price3 = "order for Rs.220",

                FoodImageUrl4 = "images/cwings.jpg",
                food4 = "12% OFF",
                price4 = "order for Rs.79",
                FoodImageUrl5 = "images/roti.jpg",
                food5 = "15% OFF",
                price5 = "order for Rs.60",
                FoodImageUrl6 = "images/vburger.jpg",
                food6 = "5% OFF",
                price6 = "order for Rs.69",

            };
            return fpd;
        }
    }
}
