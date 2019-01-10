
namespace BasketAPILibrary
{
    public static class Basket
    {
        public static IBasketAPI BasketAPIClient()
        {
            return new BasketAPI();
        }
    }
}
