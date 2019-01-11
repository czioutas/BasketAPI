
using System;

namespace BasketAPILibrary
{
    public static class Basket
    {
        public static IBasketAPI BasketAPIClient(Action<BasketOptions> configuration)
        {
            if (configuration == null) throw new ArgumentNullException("Missing Configuration");
            BasketOptions settings = new BasketOptions();
            configuration(settings);

            return new BasketAPI(settings);
        }
    }
}
