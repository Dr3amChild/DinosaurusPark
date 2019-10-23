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

function show(paging) {
    const area = document.getElementById("dinosaurus-area");
    area.innerHTML = "";
    for (let dinosaur of paging.items) {
        const child = document.createElement("div");
        child.className = "dinosaur-card alert alert-info";
        child.innerHTML =
            `<img class='dinosaur-photo img-thumbnail' src="img/no-photo.png" />
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

function setPaging(paging, onClick) {
    const pagingList = document.getElementById("paging-list");
    pagingList.innerHTML = "";
    for (let pageNum = 1; pageNum <= paging.pagesCount; pageNum++) {
        const page = document.createElement("li");
        page.className = pageNum === paging.pageNumber ? "page-item active" : "page-item";
        page.setAttribute("page-num", pageNum);
        page.addEventListener("click", onClick);
        page.innerHTML = `<span class='page-link'>${pageNum}</span>`;
        pagingList.appendChild(page);
    }
}

async function onPageClick(e) {
    const pageNum = e.currentTarget.getAttribute("page-num");
    const pageSize = 10; //todo replace with wariable
    const result = await loadDinosaurs(pageNum, pageSize);
    const pages = document.getElementsByClassName("page-item");
    for (let page of pages) {
        page.className = page.getAttribute("page-num") === pageNum ? "page-item active" : "page-item";
    }
    show(result);
}

async function onLoadInfoClick(id) {
    const info = await loadById(id);
    setDinosaurInfo(info);
    $("#dinosaur-modal").modal();
}

function setDinosaurInfo(info) {
    document.getElementById("name-value").innerText = info.name;
    document.getElementById("species-value").innerText = info.species;
    document.getElementById("description-value").innerText = info.description;
}