﻿document.addEventListener('DOMContentLoaded', function () {
    const degreeModalElement = document.getElementById('degreeModal');
    const degreeModal = new bootstrap.Modal(degreeModalElement);
    let degrees = [];

    function addDegree(educationalInstitution, major, educationalLevel, city, startDate, endDate, description) {
        degrees.push({
            EducationalInstitution: educationalInstitution,
            Major: major,
            EducationalLevel: educationalLevel,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        });
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
        // Update the hidden input for DegreesJson with the current degrees array as a JSON string
        document.getElementById('degreesJson').value = JSON.stringify(degrees);
    }

    document.getElementById('addDegreeButton').addEventListener('click', function () {
        const educationalInstitution = document.getElementById('educationalInstitution').value;
        const major = document.getElementById('major').value;
        const educationalLevel = document.getElementById('educationalLevel').value;
        const city = document.getElementById('city').value;
        const startDate = document.getElementById('startDate').value;
        const endDate = document.getElementById('endDate').value;
        const description = document.getElementById('description').value;

        addDegree(educationalInstitution, major, educationalLevel, city, startDate, endDate, description);
        degreeModal.hide();
        clearDegreeModalInputs();
    });

    function clearDegreeModalInputs() {
        document.getElementById('educationalInstitution').value = '';
        document.getElementById('major').value = '';
        document.getElementById('educationalLevel').value = '';
        document.getElementById('city').value = '';
        document.getElementById('startDate').value = '';
        document.getElementById('endDate').value = '';
        document.getElementById('description').value = '';
    }

    document.getElementById('degreeList').addEventListener('click', function (event) {
        if (event.target.classList.contains('editDegreeButton')) {
            const degreeItem = event.target.closest('.degree-item');
            const index = degreeItem.getAttribute('data-index');
            const degree = degrees[index];

            // Fill the modal inputs with the selected degree's data
            document.getElementById('educationalInstitution').value = degree.EducationalInstitution;
            document.getElementById('major').value = degree.Major;
            document.getElementById('educationalLevel').value = degree.EducationalLevel;
            document.getElementById('city').value = degree.City;
            document.getElementById('startDate').value = degree.StartDate;
            document.getElementById('endDate').value = degree.EndDate;
            document.getElementById('description').value = degree.Description;

            // Remove the degree from the array so it can be edited
            degrees.splice(index, 1);
            updateDegreeList();
            updateDegreesJson();
            degreeModal.show();
        }
    });

    document.getElementById('degreeList').addEventListener('click', function (event) {
        if (event.target.classList.contains('deleteDegreeButton')) {
            const degreeItem = event.target.closest('.degree-item');
            const index = degreeItem.getAttribute('data-index');
            degrees.splice(index, 1);
            updateDegreeList();
            updateDegreesJson();
        }
    });

    document.getElementById('submit').addEventListener('click', function () {
        document.getElementById('degreesJson').value = JSON.stringify(degrees);
    });
});
