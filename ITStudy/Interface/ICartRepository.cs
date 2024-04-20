using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface ICartRepository
    {
        bool AddtoCart(long SutdnetId, CartItem_Add CartItems);
        List<Cart_Get> GetByUserId(long UserId);
        bool RemoveCartItem(long CartItemId);
    }
}
