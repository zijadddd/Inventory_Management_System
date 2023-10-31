using server.Models.In;
using server.Models.Out;

namespace server.Services.Interfaces;

public interface ISupplierService {
    Task<SupplierOut> CreateAnSupplier(SupplierIn supplierIn);
    Task<SupplierOut> UpdateAnSupplier(int supplierId, SupplierIn supplierIn);
    Task<List<SupplierOut>> GetAllSuppliers();
    Task<SupplierOut> GetAnSupplier(int supplierId);
    Task<SupplierOut> DeleteAnSupplier(int supplierId);
}
