using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models.In;
using server.Models.Out;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase {
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService) {
        _supplierService = supplierService;
    }

    [HttpPost, Authorize(Roles = "Employee, Admin")]
    public async Task<ActionResult<SupplierOut>> CreateAnSupplier(SupplierIn supplierIn) {
        if (supplierIn == null) return BadRequest("You must fill the data to add the supplier.");
        try {
            if (ModelState.IsValid) {
                var supplier = await _supplierService.CreateAnSupplier(supplierIn);
                return Ok(supplier);
            }
            return BadRequest("Supplier data is not good.");
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{supplierId}"), Authorize(Roles = "Employee, Admin")]
    public async Task<ActionResult<SupplierOut>> UpdateAnSupplier(string supplierId, [FromBody] SupplierIn supplierIn) {
        if (supplierIn == null) return BadRequest("You must fill the data to add an supplier.");
        try {
            if (ModelState.IsValid) {
                var supplier = await _supplierService.UpdateAnSupplier(int.Parse(supplierId), supplierIn);
                return Ok(supplier);
            }

            return BadRequest("Supplier data is not good.");
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{supplierId}"), Authorize(Roles = "Employee, Admin")]
    public async Task<ActionResult<SupplierOut>> GetAnSupplier(string supplierId) {
        if (supplierId == null) return BadRequest("You must provide an id to get an supplier");
        try {
            var supplier = await _supplierService.GetAnSupplier(int.Parse(supplierId));
            return Ok(supplier);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet, Authorize(Roles = "Employee, Admin")]
    public async Task<ActionResult<List<SupplierOut>>> GetAllSuppliers() {
        try {
            var suppliers = await _supplierService.GetAllSuppliers();
            return Ok(suppliers);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{supplierId}"), Authorize(Roles = "Employee, Admin")]
    public async Task<ActionResult<SupplierOut>> DeleteAnSupplier(string supplierId) {
        try {
            var supplier = await _supplierService.DeleteAnSupplier(int.Parse(supplierId));
            return Ok(supplier);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
