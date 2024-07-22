document.addEventListener("DOMContentLoaded", function () {
  const gallery = document.getElementById("gallery");
  const modalImage = document.getElementById("modalImage");
  const imageModal = new bootstrap.Modal(document.getElementById("imageModal"));

  // Örnek resim URL'leri
  const images = [
    "https://picsum.photos/id/1018/800/600",
    "https://picsum.photos/id/1015/800/600",
    "https://picsum.photos/id/1019/800/600",
    "https://picsum.photos/id/1020/800/600",
    "https://picsum.photos/id/1021/800/600",
    "https://picsum.photos/id/1022/800/600",
  ];

  // Resimleri galeriye ekle
  images.forEach((src, index) => {
    const col = document.createElement("div");
    col.className = "col-md-4 col-sm-6 gallery-item";
    col.innerHTML = `<img src="${src}" alt="Resim ${
      index + 1
    }" class="img-fluid">`;
    gallery.appendChild(col);

    col.addEventListener("click", function () {
      modalImage.src = src;
      imageModal.show();
    });
  });
});
