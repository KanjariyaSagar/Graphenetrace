using WebApplication2.Models.ViewModels;

namespace WebApplication2.Services
{
    public interface IPatientPdfService
    {
        byte[] CreatePatientReport(PatientRowVM patient);
    }
}
