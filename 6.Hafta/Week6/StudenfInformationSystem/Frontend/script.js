const API_URL = "https://localhost:7208/api/Students";
const studentForm = document.getElementById("studentForm");
const studentTable = document
  .getElementById("studentTable")
  .getElementsByTagName("tbody")[0];

// Form submit event
studentForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  if (validateForm()) {
    const student = {
      id: parseInt(document.getElementById("studentId").value),
      firstName: document.getElementById("firstName").value,
      lastName: document.getElementById("lastName").value,
      studentNumber: document.getElementById("studentNumber").value,
      grade: parseInt(document.getElementById("grade").value),
    };

    const existingStudent = await getStudentById(student.id);
    if (existingStudent) {
      await updateStudent(student);
    } else {
      await createStudent(student);
    }

    studentForm.reset();
    loadStudents();
  }
});

// Validate form
function validateForm() {
  const id = document.getElementById("studentId").value;
  const firstName = document.getElementById("firstName").value;
  const lastName = document.getElementById("lastName").value;
  const studentNumber = document.getElementById("studentNumber").value;
  const grade = document.getElementById("grade").value;

  if (!id || !firstName || !lastName || !studentNumber || !grade) {
    alert("Lütfen tüm alanları doldurun.");
    return false;
  }

  if (isNaN(id) || id < 1) {
    alert("Geçerli bir ID girin (pozitif tam sayı).");
    return false;
  }

  if (isNaN(grade) || grade < 1 || grade > 12) {
    alert("Geçerli bir sınıf numarası girin (1-12 arası).");
    return false;
  }

  return true;
}

// Get student by ID
async function getStudentById(id) {
  try {
    const response = await fetch(`${API_URL}/${id}`);
    if (response.ok) {
      return await response.json();
    }
    return null;
  } catch (error) {
    console.error("Öğrenci bilgisi alınırken hata oluştu:", error);
    return null;
  }
}

// Create student
async function createStudent(student) {
  try {
    const response = await fetch(API_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(student),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(JSON.stringify(errorData, null, 2));
    }

    alert("Öğrenci başarıyla eklendi.");
  } catch (error) {
    console.error("Hata:", error);
    alert("Hata: " + error.message);
  }
}

// Update student
async function updateStudent(student) {
  try {
    const response = await fetch(`${API_URL}/${student.id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(student),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(JSON.stringify(errorData, null, 2));
    }

    alert("Öğrenci başarıyla güncellendi.");
  } catch (error) {
    console.error("Hata:", error);
    alert("Hata: " + error.message);
  }
}

// Delete student
async function deleteStudent(id) {
  if (confirm("Bu öğrenciyi silmek istediğinize emin misiniz?")) {
    try {
      const response = await fetch(`${API_URL}/${id}`, { method: "DELETE" });
      if (!response.ok) {
        throw new Error("Öğrenci silinemedi.");
      }
      loadStudents();
      alert("Öğrenci başarıyla silindi.");
    } catch (error) {
      alert("Hata: " + error.message);
    }
  }
}

// Load students
async function loadStudents() {
  try {
    const response = await fetch(API_URL);
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const students = await response.json();
    displayStudents(students);
  } catch (error) {
    console.error("Öğrenciler yüklenirken hata oluştu:", error);
    alert(`Öğrenciler yüklenemedi. Hata: ${error.message}`);
  }
}

// Display students in table
function displayStudents(students) {
  studentTable.innerHTML = "";
  students.forEach((student) => {
    const row = studentTable.insertRow();
    row.innerHTML = `
            <td>${student.id}</td>
            <td>${student.firstName}</td>
            <td>${student.lastName}</td>
            <td>${student.studentNumber}</td>
            <td>${student.grade}</td>
            <td>
                <button onclick="editStudent(${student.id})">Düzenle</button>
                <button onclick="deleteStudent(${student.id})">Sil</button>
            </td>
        `;
  });
}

// Edit student
function editStudent(id) {
  fetch(`${API_URL}/${id}`)
    .then((response) => response.json())
    .then((student) => {
      document.getElementById("studentId").value = student.id;
      document.getElementById("firstName").value = student.firstName;
      document.getElementById("lastName").value = student.lastName;
      document.getElementById("studentNumber").value = student.studentNumber;
      document.getElementById("grade").value = student.grade;
    })
    .catch((error) =>
      console.error("Öğrenci bilgileri alınırken hata oluştu:", error)
    );
}

// Initial load
loadStudents();
