using SkillSeek.Application.DTOs.Professional;

namespace SkillSeek.Application.Interfaces.Services;

public interface IProfessionalService
{
    void RegisterProfessional(ProfessionalDto professional);

    List<ProfessionalDto> GetAllProfessionals(bool? isActionCompleted = null, bool? isApproved = null);

    ProfessionalDto GetProfessionalById(Guid professionalId);

    void ApproveProfessionalStatus(Guid professionalId, bool status);
}