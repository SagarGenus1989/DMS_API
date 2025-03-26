using GLink_API.Common;
using GLink_API.Interface;
using GLink_API.Model;
using System.Reflection.Emit;

namespace GLink_API.Service
{
    public class ProductService : IProductService
    {
        private readonly IDbOperation _dBOperation;

        public ProductService(IDbOperation dBOperation)
        {
            _dBOperation = dBOperation;
        }

        public async Task<IEnumerable<ProductDto>> GetProductList(string search, string token, long userId,int flag)
        {
            var parameters = new
            {
                Action = ActionNameConstants.ProductAction,
                Token = token,
                UserId = userId,
                Flag = flag,
                Search = search
            };

            return await _dBOperation.ExecuteStoredProcedureListAsync<ProductDto>(StoredProcedureConstants.GetProductDetails, parameters);
        }
    }
}
