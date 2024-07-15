document.addEventListener("DOMContentLoaded", function () {
  const inputs = document.querySelectorAll("input, textarea, select");
  inputs.forEach((input) => input.addEventListener("input", updateCV));

  document.getElementById("bgColor").addEventListener("input", updateStyles);
  document.getElementById("leftColor").addEventListener("input", updateStyles);
  document
    .getElementById("nameBoxColor")
    .addEventListener("input", updateStyles);
  document
    .getElementById("nameBoxTextColor")
    .addEventListener("input", updateStyles);
  document
    .getElementById("fontFamily")
    .addEventListener("change", updateStyles);
  document
    .getElementById("photoShape")
    .addEventListener("change", updateStyles);
  document
    .getElementById("underlineStyle")
    .addEventListener("change", updateStyles);
  document
    .getElementById("underlineColor")
    .addEventListener("input", updateStyles);

  updateEducationFields();
  updateSkillFields();
  updateCV();
  updateStyles();
});

function updateCV() {
  document.getElementById("cvName").textContent =
    document.getElementById("name").value.toUpperCase() || "AD SOYAD";
  document.getElementById("cvTitle").textContent =
    document.getElementById("title").value.toUpperCase() || "UNVAN";
  document.getElementById("cvContact").innerHTML = `
        ${document.getElementById("phone").value}<br>
        ${document.getElementById("email").value}<br>
        ${document.getElementById("web").value}<br>
        ${document.getElementById("address").value}
    `;

  let educationContent = `<p>${
    document.getElementById("educationDescription").value
  }</p>`;
  const educationCount = document.getElementById("educationCount").value;
  for (let i = 1; i <= educationCount; i++) {
    educationContent += `<p>${document.getElementById(`school${i}`).value} - ${
      document.getElementById(`schoolDesc${i}`).value
    }</p>`;
  }
  document.getElementById("cvEducation").innerHTML = educationContent;

  let skillsContent = "";
  const skillCount = document.getElementById("skillCount").value;
  for (let i = 1; i <= skillCount; i++) {
    skillsContent += `<p>${document.getElementById(`skill${i}`).value}</p>`;
  }
  document.getElementById("cvSkills").innerHTML = skillsContent;

  document.getElementById("cvAbout").textContent =
    document.getElementById("about").value;
  document.getElementById("cvExperience").textContent =
    document.getElementById("experience").value;
}

function updateStyles() {
  const cv = document.getElementById("cv");
  cv.style.backgroundColor = document.getElementById("bgColor").value;
  document.getElementById("leftColumn").style.backgroundColor =
    document.getElementById("leftColor").value;
  document.getElementById("nameBox").style.backgroundColor =
    document.getElementById("nameBoxColor").value;
  document.getElementById("nameBox").style.color =
    document.getElementById("nameBoxTextColor").value;
  cv.style.fontFamily = document.getElementById("fontFamily").value;

  const photoShape = document.getElementById("photoShape").value;
  const photoContainer = document.getElementById("photoContainer");
  photoContainer.style.borderRadius =
    photoShape === "circle"
      ? "50%"
      : photoShape === "triangle"
      ? "50% 50% 0 0"
      : "0";

  const underlineStyle = document.getElementById("underlineStyle").value;
  const underlineColor = document.getElementById("underlineColor").value;
  document.querySelectorAll("#cv h2").forEach((h2) => {
    h2.style.borderBottomStyle = underlineStyle;
    h2.style.borderBottomColor = underlineColor;
  });
}

function updateEducationFields() {
  const count = document.getElementById("educationCount").value;
  const container = document.getElementById("educationFields");
  container.innerHTML = "";
  for (let i = 1; i <= count; i++) {
    container.innerHTML += `
      <div class="row">
      <input type="text" id="school${i}" placeholder="Okul ${i}">
        <input type="text" id="schoolDesc${i}" placeholder="Açıklama">
      </div>
    `;
  }
  updateCV();
}

function updateSkillFields() {
  const count = document.getElementById("skillCount").value;
  const container = document.getElementById("skillFields");
  container.innerHTML = "";
  for (let i = 1; i <= count; i++) {
    container.innerHTML += `
      <div class="row">
        <input type="text" id="skill${i}" placeholder="Yetenek ${i}">
      </div>
    `;
  }
  updateCV();
}
