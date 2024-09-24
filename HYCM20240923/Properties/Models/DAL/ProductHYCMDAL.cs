using HYCM20240923.Properties.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HYCM20240923.Properties.Models.DAL
{
    public class ProductHYCMDAL
    {
        readonly HYCMContext _context;

        public ProductHYCMDAL(HYCMContext context)
        {
            _context = context;
        }

        //Crear
        public async Task<int> Create(ProductHYCM productHYCM)
        {
            _context.Add(productHYCM);
            return await _context.SaveChangesAsync();
        }

        //Obtener por ID
        public async Task<ProductHYCM> GetById(int id)
        {
            var products = await _context.ProductsHYCM.FirstOrDefaultAsync(s => s.Id == id);
            return products != null ? products : new ProductHYCM();
        }

        //Editar
        public async Task<int> Edit(ProductHYCM productHYCM)
        {
            int result = 0;
            var productUpdate = await GetById(productHYCM.Id);
            if (productUpdate.Id != 0)
            {
                productUpdate.NombreHYCM = productHYCM.NombreHYCM;
                productUpdate.DescripcionHYCM = productHYCM.DescripcionHYCM;
                productUpdate.PrecioHYCM = productHYCM.PrecioHYCM;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productDelete = await GetById(id);
            if (productDelete.Id != 0)
            {
                _context.ProductsHYCM.Remove(productDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Buscar productos con filtros
        private IQueryable<ProductHYCM> Query(ProductHYCM product)
        {
            var query = _context.ProductsHYCM.AsQueryable();
            if (!string.IsNullOrWhiteSpace(product.NombreHYCM))
                query = query.Where(s => s.NombreHYCM.Contains(product.NombreHYCM));
            return query;
        }

        //Conteo de resultados
        public async Task<int> CountSearch(ProductHYCM product)
        {
            return await Query(product).CountAsync();
        }

        public async Task<List<ProductHYCM>> Search(ProductHYCM product, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(product);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
