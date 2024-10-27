document.addEventListener('DOMContentLoaded', function () {
    const professionalExperienceModalElement = document.getElementById('professionalExperienceModal');
    const professionalExperienceModal = new bootstrap.Modal(professionalExperienceModalElement);

    professionalExperienceModalElement.addEventListener('show.bs.modal', function () {
        document.getElementById('companyName').value = '';
        document.getElementById('experienceCity').value = '';
        document.getElementById('experienceStartDate').value = '';
        document.getElementById('experienceEndDate').value = '';
        document.getElementById('experienceDescription').value = '';
    });

    document.getElementById('addProfessionalExperienceButton').addEventListener('click', function () {
        const companyName = document.getElementById('companyName').value;
        const city = document.getElementById('experienceCity').value;
        const startDate = document.getElementById('experienceStartDate').value;
        const endDate = document.getElementById('experienceEndDate').value;
        const description = document.getElementById('experienceDescription').value;

        const experienceList = document.getElementById('professionalExperienceList');
        const newExperience = document.createElement('p');
        newExperience.textContent = `${companyName} - ${city} (${startDate} - ${endDate})`;
        experienceList.appendChild(newExperience);

        const experiencesInput = document.querySelector('input[name="ProfessionalExperiences"]');
        let currentExperiences = JSON.parse(experiencesInput.value || "[]");
        currentExperiences.push({
            CompanyName: companyName,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        });
        experiencesInput.value = JSON.stringify(currentExperiences);

        professionalExperienceModal.hide();
    });
});