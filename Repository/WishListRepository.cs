﻿using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.CodeAnalysis;

namespace E_commerce_MVC.Repository
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        public WishListRepository(Context context) : base(context)
        {

        }
        public List<WishList> GetAllbyCustomerId(string id)
        {
            List<WishList> wishLists = context.WishLists.
                Where(item => item.Customer_Id == id && item.IsDeleted == false).ToList();
            return wishLists;
        }
        public bool ExistOrNot(string customerId, int productId)
        {
            return context.WishLists.Any(w => w.Customer_Id == customerId && w.Product_Id == productId);
        }

        public void HardDelete(WishList wishList)
        {
            context.Remove(wishList);
        }
        public WishList getwishlistByProductId(int id)
        {
            return context.WishLists.FirstOrDefault(w => w.Product_Id == id);
        }

    }
}
