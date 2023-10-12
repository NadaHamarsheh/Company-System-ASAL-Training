document.addEventListener("DOMContentLoaded", function () {
    const loadButton = document.getElementById('loadButton');
    loadButton.addEventListener('click', function () {
        getAllDepartments();
    });

    // Your other JavaScript code here...
});

function getAllDepartments() {
    fetch('http://localhost:5077/Department')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch departments');
            }
            return response.json();
        })
        .then(data => {
            _displayItems(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

function _displayItems(data) {
    const tBody = document.getElementById('TableContent');
    tBody.innerHTML = "";

    data.forEach(item => {
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.textContent = item.name;

        let td2 = tr.insertCell(1);
        td2.textContent = item.description;

        let td3 = tr.insertCell(2);
        td3.textContent = item.createdBy;

        let td4 = tr.insertCell(3);
        td4.textContent = item.createdOn;

        let td5 = tr.insertCell(4);
        td5.textContent = item.modifiedBy;

        let td6 = tr.insertCell(5);
        td6.textContent = item.modifiedOn;

        let td7 = tr.insertCell(6);
        let editButton = document.createElement('button');
        editButton.innerText = 'Edit';
        editButton.addEventListener('click', function () {
            displayEditForm(item.id);
        });
        td7.appendChild(editButton);

        let td8 = tr.insertCell(7);
        let deleteButton = document.createElement('button');
        deleteButton.innerText = 'Delete';
        deleteButton.addEventListener('click', function () {
            deleteItem(item.id);
        });
        td8.appendChild(deleteButton);
    });
}

