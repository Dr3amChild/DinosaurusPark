﻿async function generate(speciesCount, dinosaursCount) {
    const response = await window.fetch("/generation/create", {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify({ speciesCount, dinosaursCount })
    });
    return await response.json();
}

async function loadById(id) {
    const response = await window.fetch(`/get?id=${id}`, {
        method: "GET"
    });
    return await response.json();
}

async function loadDinosaurs(pageNumber, pageSize) {
    const response = await window.fetch(`/all?pageSize=${pageSize}&pageNumber=${pageNumber}`, {
        method: "GET"
    });
    return await response.json();
}

function show(dinosaurs) {
    const area = document.getElementById("dinosaurus-area");

    for (let dinosaur of dinosaurs) {
        const child = document.createElement("div");
        child.className = "dinosaur-card alert alert-info";
        child.innerHTML =
            `<img class='dinosaur-photo' src="img/no-photo.png" />
             <div class="row-header">Динозавр</div>
             <div class="row-value">${dinosaur.name}</div>
             <div class="row-header">Вид</div>
             <div class="row-value">${dinosaur.species}</div>`;

        const button = document.createElement("button");
        button.className = "btn btn-info dinusaur-info-btn";
        button.innerText = "Подробнее";
        button.onclick = () => onLoadInfoClick(dinosaur.id);
        child.appendChild(button);

        area.appendChild(child);
    }
}

async function onLoadInfoClick(id) {
    const info = await loadById(id);
    alert(info.name);
}