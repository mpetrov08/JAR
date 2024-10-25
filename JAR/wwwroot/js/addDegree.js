document.addEventListener('DOMContentLoaded', function () {
    const degreeModalElement = document.getElementById('degreeModal');
    const degreeModal = new bootstrap.Modal(degreeModalElement);

    document.getElementById('addDegreeButton').addEventListener('click', function () {
        const educationalInstitution = document.getElementById('educationalInstitution').value;
        const major = document.getElementById('major').value;
        const educationalLevel = document.getElementById('educationalLevel').value;
        const city = document.getElementById('city').value;
        const startDate = document.getElementById('startDate').value;
        const endDate = document.getElementById('endDate').value;
        const description = document.getElementById('description').value;

        const degreeList = document.getElementById('degreeList');
        const newDegree = document.createElement('p');
        newDegree.textContent = `${educationalInstitution} - ${major} (${startDate} - ${endDate})`;
        degreeList.appendChild(newDegree);

        const degreesInput = document.querySelector('input[name="Degrees"]');
        let currentDegrees = JSON.parse(degreesInput.value || "[]");
        currentDegrees.push({
            EducationalInstitution: educationalInstitution,
            Major: major,
            EducationalLevel: educationalLevel,
            City: city,
            StartDate: startDate,
            EndDate: endDate,
            Description: description
        });
        degreesInput.value = JSON.stringify(currentDegrees);

        degreeModal.hide();

        document.getElementById('educationalInstitution').value = '';
        document.getElementById('major').value = '';
        document.getElementById('educationalLevel').value = '';
        document.getElementById('city').value = '';
        document.getElementById('startDate').value = '';
        document.getElementById('endDate').value = '';
        document.getElementById('description').value = '';
    });

    degreeModalElement.addEventListener('show.bs.modal', function () {
        document.getElementById('educationalInstitution').value = '';
        document.getElementById('major').value = '';
        document.getElementById('educationalLevel').value = '';
        document.getElementById('city').value = '';
        document.getElementById('startDate').value = '';
        document.getElementById('endDate').value = '';
        document.getElementById('description').value = '';
    });
});