const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new DinosaursApi(10);    
    const result = await api.getPage(1);
    const generation = new Generation(10, 100, 10); //todo replace literals
    if (!result || !result.items.length) {
        generation.showForm();
    } else {
        generation.show(result);
        generation.setPaging(result);
    }
};

/*
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
}*/
