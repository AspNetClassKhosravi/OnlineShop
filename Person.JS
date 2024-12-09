
document.addEventListener("DOMContentLoaded", () => {
  // Attach event listeners to the buttons
  document.querySelectorAll(".btn-select").forEach((button) => {
    button.addEventListener("click", select);
  });

  document.getElementById("btn-save").addEventListener("click", save);
  document.getElementById("btn-edit").addEventListener("click", edit);
  document.getElementById("btn-delete").addEventListener("click", deleteRecord);
  document.getElementById("btn-refresh").addEventListener("click", refresh);
});

let selectedRow = null; // Variable to store the selected row for editing or deletion

function select(event) {
  // Get the row containing the clicked button
  
  const row = event.target.closest("tr");
  if (row) {
    // Extract data from the row's cells
    const firstName = row.children[1].textContent.trim();
    const lastName = row.children[2].textContent.trim();
    const email = row.children[3].textContent.trim();

    // Populate the form fields with extracted data
    document.getElementById("firstName").value = firstName;
    document.getElementById("lastName").value = lastName;
    document.getElementById("email").value = email;

    // Store the selected row for editing or deletion
    selectedRow = row;
  }
}

function save() {
  // Get the values from the form
  const firstName = document.getElementById("firstName").value.trim();
  const lastName = document.getElementById("lastName").value.trim();
  const email = document.getElementById("email").value.trim();

  // Validate input
  if (!firstName || !lastName || !email) {
    alert("All fields must be filled out!");
    return;
  }

  // Create a new row in the table with the entered data
  const table = document.querySelector("table tbody");
  const newRow = table.insertRow();
  newRow.innerHTML = `
    <th scope="row">${table.rows.length}</th>
    <td>${firstName}</td>
    <td>${lastName}</td>
    <td>${email}</td>
    <td><button style="background-color: green;color: aliceblue;" type="button" class="btn btn-select">Select</button></td>
  `;

  // Add event listener to the new "Select" button
  newRow.querySelector(".btn-select").addEventListener("click", select);

  // Clear the form fields after saving
  document.getElementById("firstName").value = '';
  document.getElementById("lastName").value = '';
  document.getElementById("email").value = '';
}

function edit() {
  
  // // Ensure that a row is selected for editing
  if (!selectedRow) {
    alert("Please select a row to edit!");
    return;
  }
  
  // save();
  // deleteRecord();

  // Get the new values from the form
  const firstName = document.getElementById("firstName").value.trim();
  const lastName = document.getElementById("lastName").value.trim();
  const email = document.getElementById("email").value.trim();

  // Validate input
  if (!firstName || !lastName || !email) {
    alert("All fields must be filled out!");
    return;
  }

  // Update the selected row with the new values
  selectedRow.children[1].textContent = firstName;
  selectedRow.children[2].textContent = lastName;
  selectedRow.children[3].textContent = email;

  selectedRow.children[4].innerHTML = `
    <td><button style="background-color: green;color: aliceblue;" type="button" class="btn btn-select">Select</button></td>
  `;

  selectedRow.querySelector(".btn-select").addEventListener("click", select);

  // Clear the form fields after editing
  document.getElementById("firstName").value = '';
  document.getElementById("lastName").value = '';
  document.getElementById("email").value = '';

  //Reset the selected row

  selectedRow = null;
}

function deleteRecord() {
  // Ensure that a row is selected for deletion
  if (!selectedRow) {
    alert("Please select a row to delete!");
    return;
  }

  // Remove the selected row from the table
  selectedRow.remove();

  // Clear the form fields after deletion
  document.getElementById("firstName").value = '';
  document.getElementById("lastName").value = '';
  document.getElementById("email").value = '';

  // Reset the selected row
  selectedRow = null;
}

function refresh() {
  // Reload the page to reset the form and table
  location.reload();
}
