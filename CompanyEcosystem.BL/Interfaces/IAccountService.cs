using CompanyEcosystem.BL.DataTransferObjects;


namespace CompanyEcosystem.BL.Interfaces
{
    public interface IAccountService
    {
        Task<EmployeeDto> AuthenticateAsync(EmployeeDto employeeDto);
        Task<EmployeeDto> RegisterAsync(EmployeeDto employeeDto);
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task Biometric(EmployeeDto employeeDto);
    }

}
