async function generate(speciesCount, dinosaursCount) {
    const response = await window.fetch("/generation/create", {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify({ speciesCount, dinosaursCount })
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
        const child = document.createElement('div');
        child.innerHTML = `<div>Динозавр ${dinosaur.name}. Вид: ${dinosaur.species}</div>`;
        area.appendChild(child);
    }
}