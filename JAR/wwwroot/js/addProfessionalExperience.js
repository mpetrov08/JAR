document.addEventListener('DOMContentLoaded', function () {
    const experienceModalElement = document.getElementById('professionalExperienceModal');
    const experienceModal = new bootstrap.Modal(experienceModalElement);
    const experiences = [];

    function addExperience(companyName, city, startDate, endDate, description) {
        experiences.push({
            CompanyName: companyName,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        });
        updateExperienceList();
    }

    function updateExperienceList() {
        const experienceList = document.getElementById('professionalExperienceList');
        experienceList.innerHTML = '';
        experiences.forEach((experience, index) => {
            const experienceItem = document.createElement('div');
            experienceItem.className = 'experience-item';
            experienceItem.setAttribute('data-index', index);
            experienceItem.innerHTML = `
                <p>${experience.CompanyName} - ${experience.City} (${experience.StartDate} - ${experience.EndDate})</p>
                <button type="button" class="btn btn-sm btn-warning editExperienceButton">Edit</button>
                <button type="button" class="btn btn-sm btn-danger deleteExperienceButton">Delete</button>
            `;
            experienceList.appendChild(experienceItem);
        });
    }

    document.getElementById('addProfessionalExperienceButton').addEventListener('click', function () {
        const companyName = document.getElementById('companyName').value;
        const city = document.getElementById('experienceCity').value;
        const startDate = document.getElementById('experienceStartDate').value;
        const endDate = document.getElementById('experienceEndDate').value;
        const description = document.getElementById('experienceDescription').value;

        addExperience(companyName, city, startDate, endDate, description);
        experienceModal.hide();
        clearExperienceModalInputs();
    });

    function clearExperienceModalInputs() {
        document.getElementById('companyName').value = '';
        document.getElementById('experienceCity').value = '';
        document.getElementById('experienceStartDate').value = '';
        document.getElementById('experienceEndDate').value = '';
        document.getElementById('experienceDescription').value = '';
    }

    document.getElementById('professionalExperienceList').addEventListener('click', function (event) {
        if (event.target.classList.contains('editExperienceButton')) {
            const experienceItem = event.target.closest('.experience-item');
            const index = experienceItem.getAttribute('data-index');
            const experience = experiences[index];

            document.getElementById('companyName').value = experience.CompanyName;
            document.getElementById('experienceCity').value = experience.City;
            document.getElementById('experienceStartDate').value = experience.StartDate;
            document.getElementById('experienceEndDate').value = experience.EndDate;
            document.getElementById('experienceDescription').value = experience.Description;

            experienceModal.show();
            experiences.splice(index, 1);
            updateExperienceList();
        }
    });

    document.getElementById('professionalExperienceList').addEventListener('click', function (event) {
        if (event.target.classList.contains('deleteExperienceButton')) {
            const experienceItem = event.target.closest('.experience-item');
            const index = experienceItem.getAttribute('data-index');
            experiences.splice(index, 1);
            updateExperienceList();
        }
    });
});