const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new DinosaursApi(Constants.PageSize);    
    const result = await api.getPage(1);
    if (!result || !result.items.length) {
        window.location.href = "/generation";
    } else {
        const area = document.getElementById("dinosaurs-area");
        ReactDOM.render(React.createElement(Cards, { items: result.items }), area);
        const paging = new Paging(api, "paging-nav", async (pageNumber) => await showDinosaursPage(api, pageNumber));
        paging.render(result, true);
    }
};

async function showDinosaursPage(api, pageNumber) {
    const data = await api.getPage(pageNumber);
    const area = document.getElementById("dinosaurs-area");
    ReactDOM.render(React.createElement(Cards, { items: data.items }), area);
}