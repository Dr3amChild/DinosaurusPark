const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new DinosaursApi(10);    
    const result = await api.getPage(1);
    if (!result || !result.items.length) {
        const area = document.getElementById("no-data-alert");
        area.style.display = "block";
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(
            React.createElement(GenerationForm,
            {
                onClick: async () => await onGenerateClick(api),
                species: 10,
                dinosaurs: 100
            }),
            area);
    } else {
        show(result);
        setPaging(result, (e) => onPageClick(e, api));
    }
}

async function onGenerateClick(api) {
    const speciesCount = parseInt(document.getElementById("species-count-text").value);
    const dinosaursCount = parseInt(document.getElementById("dinosaurs-count-text").value);
    await api.generate(speciesCount, dinosaursCount);
    const result = await api.getPage(1);
    document.getElementById("no-data-alert").style.display = "none";
    window.show(result);
    setPaging(result, (e) => onPageClick(e, api));
}

function show(paging) {
    const area = document.getElementById("Dinosaurs-area");
    ReactDOM.unmountComponentAtNode(area);
    ReactDOM.render(React.createElement(Cards, { items: paging.items }), area);
}

function setPaging(paging, onClick) {
    const pagingArea = document.getElementById("paging-nav");
    ReactDOM.unmountComponentAtNode(pagingArea);
    ReactDOM.render(React.createElement(
        Paging,
        {
            pagesCount: paging.pagesCount,
            activePage: paging.pageNumber,
            onClick
        }), pagingArea);
}

async function onPageClick(e, api) {
    const pageNum = e.currentTarget.getAttribute("page-num");
    const result = await api.getPage(pageNum);
    const pages = document.getElementsByClassName("page-item");
    for (let page of pages) {
        page.className = page.getAttribute("page-num") === pageNum ? "page-item active" : "page-item";
    }
    show(result);
}