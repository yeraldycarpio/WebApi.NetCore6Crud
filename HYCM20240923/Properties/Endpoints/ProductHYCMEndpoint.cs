using HYCM.DTOs.ProductHYCMDTOs;
using HYCM20240923.Properties.Models.DAL;
using HYCM20240923.Properties.Models.EN;

namespace HYCM20240923.Properties.Endpoints
{
    public static class ProductHYCMEndpoint
    {
        public static void AddProductHYCMEndpoints(this WebApplication app)
        {
            //Metodo para Buscar
            app.MapPost("/product/search", async (SearchQueryProductHYCMDTO productHYCMDTO, ProductHYCMDAL productHYCMDAL) =>
            {
                var product = new ProductHYCM
                {
                    NombreHYCM = productHYCMDTO.NombreHYCM_Like != null ? productHYCMDTO.NombreHYCM_Like : string.Empty
                };

                var products = new List<ProductHYCM>();
                int countRow = 0;

                if (productHYCMDTO.SendRowCount == 2)
                {
                    products = await productHYCMDAL.Search(product, skip: productHYCMDTO.Skip, take: productHYCMDTO.Take);
                    if (products.Count > 0)
                    {
                        countRow = await productHYCMDAL.CountSearch(product);
                    }
                }
                else
                {
                    products = await productHYCMDAL.Search(product, skip: productHYCMDTO.Skip, take: productHYCMDTO.Take);
                }

                var productResult = new SearchResultProductHYCMDTO
                {
                    Data = new List<SearchResultProductHYCMDTO.ProductHYCM>(),
                    CountRow = countRow
                };

                products.ForEach(s =>
                {
                    productResult.Data.Add(new SearchResultProductHYCMDTO.ProductHYCM
                    {
                        Id = s.Id,
                        NombreHYCM = s.NombreHYCM,
                        DescripcionHYCM = s.DescripcionHYCM,
                        PrecioHYCM = s.PrecioHYCM
                    });
                });

                return productResult;
            });

            //Metodo para Obtener por ID
            app.MapGet("/product/{id}", async (int id, ProductHYCMDAL productDAL) =>
            {
                var product = await productDAL.GetById(id);

                var productResult = new GetIdResultProductHYCMDTO
                {
                    Id = product.Id,
                    NombreHYCM = product.NombreHYCM,
                    DescripcionHYCM = product.DescripcionHYCM,
                    PrecioHYCM = product.PrecioHYCM
                };

                if (productResult.Id > 0)
                    return Results.Ok(productResult);
                else
                    return Results.NotFound(productResult);
            });

            //Crear nuevo producto
            app.MapPost("/product", async (CreateProductHYCMDTO create, ProductHYCMDAL productDAL) =>
            {
                var product = new ProductHYCM
                {
                    NombreHYCM = create.NombreHYCM,
                    DescripcionHYCM = create.DescripcionHYCM,
                    PrecioHYCM = create.PrecioHYCM
                };

                int result = await productDAL.Create(product);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //Editar
            app.MapPut("/product", async (EditProductHYCMDTO edit, ProductHYCMDAL productDAL) =>
            {
                var product = new ProductHYCM
                {
                    Id = edit.Id,
                    NombreHYCM = edit.NombreHYCM,
                    DescripcionHYCM = edit.DescripcionHYCM,
                    PrecioHYCM = edit.PrecioHYCM
                };

                int result = await productDAL.Edit(product);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //Eliminar
            app.MapDelete("/product/{id}", async (int id, ProductHYCMDAL delete) =>
            {
                int result = await delete.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
