using GLink_API.Model;
using Microsoft.Extensions.Primitives;

namespace GLink_API.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductList(string search, string token,Int64 userId,int flag);
    }
}
