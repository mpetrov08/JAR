document.addEventListener('DOMContentLoaded', function () {
    const experienceModalElement = document.getElementById('professionalExperienceModal');
    const experienceModal = new bootstrap.Modal(experienceModalElement);

    let experiences = document.getElementById('initialProfessionalExperiences')
        ? JSON.parse(document.getElementById('initialProfessionalExperiences').value)
        : [];

    let editingExperienceIndex = null; // Track the index of the experience being edited, if any

    function addExperience(companyName, city, startDate, endDate, description) {
        const experience = {
            CompanyName: companyName,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        };
        experiences.push(experience); // Add new experience
        updateExperienceList();
        updateExperiencesJson();
    }

    function updateExperience(index, companyName, city, startDate, endDate, description) {
        experiences[index] = { // Update experience at the specified index
            CompanyName: companyName,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        };
        updateExperienceList();
        updateExperiencesJson();
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

    function updateExperiencesJson() {
        document.getElementById('professionalExperiencesJson').value = JSON.stringify(experiences);
    }

    // Handle "Add" or "Save" button click within the modal
    document.getElementById('addProfessionalExperienceButton').addEventListener('click', function () {
        const companyName = document.getElementById('companyName').value;
        const city = document.getElementById('experienceCity').value;
        const startDate = document.getElementById('experienceStartDate').value;
        const endDate = document.getElementById('experienceEndDate').value;
        const description = document.getElementById('experienceDescription').value;

        if (editingExperienceIndex !== null) {
            updateExperience(editingExperienceIndex, companyName, city, startDate, endDate, description);
            editingExperienceIndex = null; // Reset after updating
        } else {
            addExperience(companyName, city, startDate, endDate, description);
        }

        experienceModal.hide();
        clearExperienceModalInputs();
    });

    function clearExperienceModalInputs() {
        // Ensure all input fields are cleared when adding a new experience
        document.getElementById('companyName').value = '';
        document.getElementById('experienceCity').value = '';
        document.getElementById('experienceStartDate').value = '';
        document.getElementById('experienceEndDate').value = '';
        document.getElementById('experienceDescription').value = '';
    }

    // Handle click events on the experience list for edit and delete buttons
    document.getElementById('professionalExperienceList').addEventListener('click', function (event) {
        if (event.target.classList.contains('editExperienceButton')) {
            const experienceItem = event.target.closest('.experience-item');
            const index = experienceItem.getAttribute('data-index');
            const experience = experiences[index];

            // Populate modal inputs with existing experience data
            document.getElementById('companyName').value = experience.CompanyName;
            document.getElementById('experienceCity').value = experience.City;
            document.getElementById('experienceStartDate').value = experience.StartDate;
            document.getElementById('experienceEndDate').value = experience.EndDate;
            document.getElementById('experienceDescription').value = experience.Description;

            editingExperienceIndex = index; // Set the index of the experience being edited
            experienceModal.show();
        }

        if (event.target.classList.contains('deleteExperienceButton')) {
            const experienceItem = event.target.closest('.experience-item');
            const index = experienceItem.getAttribute('data-index');
            experiences.splice(index, 1); // Remove experience from the list
            updateExperienceList();
            updateExperiencesJson();
        }
    });

    // Ensure modal input fields are cleared before opening the modal for adding a new experience
    experienceModalElement.addEventListener('show.bs.modal', function () {
        if (editingExperienceIndex === null) {
            // Only clear the fields if we're not editing an existing experience
            clearExperienceModalInputs();
        }
    });

    // Handle the modal close to reset editing state
    experienceModalElement.addEventListener('hidden.bs.modal', function () {
        editingExperienceIndex = null; // Reset the editing index when modal is closed
    });

    document.getElementById('submit').addEventListener('click', function () {
        updateExperiencesJson();
    });

    updateExperienceList();
});