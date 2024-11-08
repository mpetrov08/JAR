document.addEventListener('DOMContentLoaded', function () {
    const degreeModalElement = document.getElementById('degreeModal');
    const degreeModal = new bootstrap.Modal(degreeModalElement);

    let degrees = document.getElementById('initialDegrees')
        ? JSON.parse(document.getElementById('initialDegrees').value)
        : [];

    let editingDegreeIndex = null; // Track the index of the degree being edited, if any

    function addDegree(educationalInstitution, major, educationalLevel, city, startDate, endDate, description) {
        const degree = {
            EducationalInstitution: educationalInstitution,
            Major: major,
            EducationalLevel: educationalLevel,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        };
        degrees.push(degree); // Add new degree to the list
        updateDegreeList();
        updateDegreesJson();
    }

    function updateDegree(index, educationalInstitution, major, educationalLevel, city, startDate, endDate, description) {
        degrees[index] = { // Update the degree at the specified index
            EducationalInstitution: educationalInstitution,
            Major: major,
            EducationalLevel: educationalLevel,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        };
        updateDegreeList();
        updateDegreesJson();
    }

    function updateDegreeList() {
        const degreeList = document.getElementById('degreeList');
        degreeList.innerHTML = '';

        degrees.forEach((degree, index) => {
            const degreeItem = document.createElement('div');
            degreeItem.className = 'degree-item';
            degreeItem.setAttribute('data-index', index);
            degreeItem.innerHTML = `
                <p>${degree.EducationalInstitution} - ${degree.Major} (${degree.StartDate} - ${degree.EndDate})</p>
                <button type="button" class="btn btn-sm btn-warning editDegreeButton">Edit</button>
                <button type="button" class="btn btn-sm btn-danger deleteDegreeButton">Delete</button>
            `;
            degreeList.appendChild(degreeItem);
        });
    }

    function updateDegreesJson() {
        document.getElementById('degreesJson').value = JSON.stringify(degrees);
    }

    // Handle "Add" or "Save" button click within the modal
    document.getElementById('addDegreeButton').addEventListener('click', function () {
        const educationalInstitution = document.getElementById('educationalInstitution').value;
        const major = document.getElementById('major').value;
        const educationalLevel = document.getElementById('educationalLevel').value;
        const city = document.getElementById('city').value;
        const startDate = document.getElementById('startDate').value;
        const endDate = document.getElementById('endDate').value;
        const description = document.getElementById('description').value;

        if (editingDegreeIndex !== null) {
            updateDegree(editingDegreeIndex, educationalInstitution, major, educationalLevel, city, startDate, endDate, description);
            editingDegreeIndex = null; // Clear editing index after updating
        } else {
            addDegree(educationalInstitution, major, educationalLevel, city, startDate, endDate, description);
        }

        degreeModal.hide();
        clearDegreeModalInputs();
    });

    function clearDegreeModalInputs() {
        // Ensure all input fields are cleared when adding a new degree
        document.getElementById('educationalInstitution').value = '';
        document.getElementById('major').value = '';
        document.getElementById('educationalLevel').value = '';
        document.getElementById('city').value = '';
        document.getElementById('startDate').value = '';
        document.getElementById('endDate').value = '';
        document.getElementById('description').value = '';
    }

    // Handle click events on the degree list for edit and delete buttons
    document.getElementById('degreeList').addEventListener('click', function (event) {
        if (event.target.classList.contains('editDegreeButton')) {
            const degreeItem = event.target.closest('.degree-item');
            const index = degreeItem.getAttribute('data-index');
            const degree = degrees[index];

            // Populate modal inputs with degree information
            document.getElementById('educationalInstitution').value = degree.EducationalInstitution;
            document.getElementById('major').value = degree.Major;
            document.getElementById('educationalLevel').value = degree.EducationalLevel;
            document.getElementById('city').value = degree.City;
            document.getElementById('startDate').value = degree.StartDate;
            document.getElementById('endDate').value = degree.EndDate;
            document.getElementById('description').value = degree.Description;

            editingDegreeIndex = index; // Set the index of the degree being edited
            degreeModal.show();
        }

        if (event.target.classList.contains('deleteDegreeButton')) {
            const degreeItem = event.target.closest('.degree-item');
            const index = degreeItem.getAttribute('data-index');
            degrees.splice(index, 1); // Remove the degree from the list
            updateDegreeList();
            updateDegreesJson();
        }
    });

    // Ensure modal input fields are cleared before opening the modal for adding a new degree
    document.getElementById('degreeModal').addEventListener('show.bs.modal', function () {
        if (editingDegreeIndex === null) {
            // Only clear the fields if we're not editing an existing degree
            clearDegreeModalInputs();
        }
    });

    // Handle the modal close to reset editing state
    degreeModalElement.addEventListener('hidden.bs.modal', function () {
        editingDegreeIndex = null; // Reset the editing index when modal is closed
    });

    document.getElementById('submit').addEventListener('click', function () {
        document.getElementById('degreesJson').value = JSON.stringify(degrees);
    });

    updateDegreeList();
});