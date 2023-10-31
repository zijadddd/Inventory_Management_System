using Microsoft.EntityFrameworkCore;
using server.Database;
using server.Exceptions;
using server.Models.Entities;
using server.Models.In;
using server.Models.Out;
using server.Services.Interfaces;

namespace server.Services.Implementations;

public class SupplierService : ISupplierService {
    private readonly DatabaseContext _databaseContext;

    public SupplierService(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public async Task<SupplierOut> CreateAnSupplier(SupplierIn supplierIn) {
        DateTime minDate = new DateTime(2020, 1, 1);
        DateTime maxDate = DateTime.Today;

        if (!DateTime.TryParse(supplierIn.StartDate, out DateTime inputStartDate))
            throw new SupplierInvalidDateException("start date");

        if (!(inputStartDate >= minDate && inputStartDate <= maxDate))
            throw new SupplierInvalidDateException("start date");

        if (!DateTime.TryParse(supplierIn.EndDate, out DateTime inputEndDate) && !string.IsNullOrEmpty(supplierIn.EndDate))
            throw new SupplierInvalidDateException("end date");

        if (!(inputEndDate >= minDate && inputEndDate <= maxDate) && !string.IsNullOrEmpty(supplierIn.EndDate))
            throw new SupplierInvalidDateException("end date");

        var supplierExist = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Name.Equals(supplierIn.Name));
        if (supplierExist != null) throw new SupplierAlreadyExistException();

        Supplier supplier = new Supplier {
            Name = supplierIn.Name,
            UniqueIdentificationNumber = supplierIn.UniqueIdentificationNumber,
            ValueAddedTax = double.Parse(supplierIn.ValueAddedTax),
            PhoneNumber = supplierIn.PhoneNumber,
            ContactPerson = supplierIn.ContactPerson,
            Email = supplierIn.Email,
            StartDate = DateTime.Parse(supplierIn.StartDate),
            EndDate = string.IsNullOrEmpty(supplierIn.EndDate) ? DateTime.MinValue : DateTime.Parse(supplierIn.EndDate)
        };

        await _databaseContext.Suppliers.AddAsync(supplier);
        await _databaseContext.SaveChangesAsync();

        SupplierOut supplierOut = new SupplierOut(supplier.Id.ToString(), supplier.Name, supplier.UniqueIdentificationNumber, supplier.ValueAddedTax.ToString(), supplier.PhoneNumber, supplier.ContactPerson, supplier.Email, supplier.StartDate.ToString(), supplier.EndDate.ToString());

        return supplierOut;
    }

    public async Task<SupplierOut> DeleteAnSupplier(int supplierId) {
        var supplierExist = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
        if (supplierExist == null) throw new SupplierNotFoundException();

        _databaseContext.Remove(supplierExist);
        await _databaseContext.SaveChangesAsync();

        SupplierOut supplierOut = new SupplierOut(supplierExist.Id.ToString(), supplierExist.Name, supplierExist.UniqueIdentificationNumber, supplierExist.ValueAddedTax.ToString(), supplierExist.PhoneNumber, supplierExist.ContactPerson, supplierExist.Email, supplierExist.StartDate.ToString(), supplierExist.EndDate.ToString());

        return supplierOut;
    }

    public async Task<List<SupplierOut>> GetAllSuppliers() {
        var suppliers = await _databaseContext.Suppliers.ToListAsync();
        if (suppliers.Count == 0) throw new NotASingleSupplierWasFoundException();

        List<SupplierOut> suppliersOut = new List<SupplierOut>();

        foreach (var supplier in suppliers)
            suppliersOut.Add(new SupplierOut(supplier.Id.ToString(), supplier.Name, supplier.UniqueIdentificationNumber, supplier.ValueAddedTax.ToString(), supplier.PhoneNumber, supplier.ContactPerson, supplier.Email, supplier.StartDate.ToString(), supplier.EndDate.ToString()));

        return suppliersOut;
    }

    public async Task<SupplierOut> GetAnSupplier(int supplierId) {
        var supplier = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
        if (supplier == null) throw new SupplierNotFoundException();

        SupplierOut supplierOut = new SupplierOut(supplier.Id.ToString(), supplier.Name, supplier.UniqueIdentificationNumber, supplier.ValueAddedTax.ToString(), supplier.PhoneNumber, supplier.ContactPerson, supplier.Email, supplier.StartDate.ToString(), supplier.EndDate.ToString());

        return supplierOut;
    }

    public async Task<SupplierOut> UpdateAnSupplier(int supplierId, SupplierIn supplierIn) {
        DateTime minDate = new DateTime(2020, 1, 1);
        DateTime maxDate = DateTime.Today;

        if (!DateTime.TryParse(supplierIn.StartDate, out DateTime inputStartDate))
            throw new SupplierInvalidDateException("start date");

        if (!(inputStartDate >= minDate && inputStartDate <= maxDate))
            throw new SupplierInvalidDateException("start date");

        if (!DateTime.TryParse(supplierIn.EndDate, out DateTime inputEndDate) && !string.IsNullOrEmpty(supplierIn.EndDate))
            throw new SupplierInvalidDateException("end date");

        if (!(inputEndDate >= minDate && inputEndDate <= maxDate) && !string.IsNullOrEmpty(supplierIn.EndDate))
            throw new SupplierInvalidDateException("end date");

        var supplier = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
        if (supplier == null) throw new SupplierNotFoundException();

        supplier.Name = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Name.Equals(supplierIn.Name) && s.Id != supplierId) == null ? supplierIn.Name : throw new SupplierWithThatDataAlreadyExistException("name");
        supplier.UniqueIdentificationNumber = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.UniqueIdentificationNumber.Equals(supplierIn.UniqueIdentificationNumber) && s.Id != supplierId) == null ? supplierIn.UniqueIdentificationNumber : throw new SupplierWithThatDataAlreadyExistException("unique identification number");
        supplier.ValueAddedTax = double.Parse(supplierIn.ValueAddedTax);
        supplier.PhoneNumber = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.PhoneNumber.Equals(supplierIn.PhoneNumber) && s.Id != supplierId) == null ? supplierIn.PhoneNumber : throw new SupplierWithThatDataAlreadyExistException("phone number");
        supplier.ContactPerson = supplierIn.ContactPerson;
        supplier.Email = await _databaseContext.Suppliers.FirstOrDefaultAsync(s => s.Email.Equals(supplierIn.Email) && s.Id != supplierId) == null ? supplierIn.Email : throw new SupplierWithThatDataAlreadyExistException("email");
        supplier.StartDate = DateTime.Parse(supplierIn.StartDate);
        supplier.EndDate = string.IsNullOrEmpty(supplierIn.EndDate) ? DateTime.MinValue : DateTime.Parse(supplierIn.EndDate);

        _databaseContext.Suppliers.Update(supplier);
        await _databaseContext.SaveChangesAsync();

        SupplierOut supplierOut = new SupplierOut(supplier.Id.ToString(), supplier.Name, supplier.UniqueIdentificationNumber, supplier.ValueAddedTax.ToString(), supplier.PhoneNumber, supplier.ContactPerson, supplier.Email, supplier.StartDate.ToString(), supplier.EndDate.ToString());

        return supplierOut;
    }
}
