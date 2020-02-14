const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const infoApi = new ParkInfoApi(Constants.PageSize);
    try {
        const parkInfo = await infoApi.getParkInfo();
        const area = document.getElementById("info-area");
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(React.createElement(ParkInfo, {
            info: parkInfo,
            onSpeciesInfoClick: async () => await onSpeciesInfoClick(infoApi, 1),
            onDeleteParkClick: async () => await onDeleteParkClick(infoApi, new DinosaursApi(Constants.PageSize)),
        }), area);
    } catch (e) {
        window.location.href = "/generation";
    }
};

async function onSpeciesInfoClick(api, pageNum) {
    const speciesInfo = await api.getSpeciesInfo(pageNum);
    const infoArea = document.getElementById("species-info-area");
    ReactDOM.render(React.createElement(SpeciesInfo, {
        info: speciesInfo.items,
        onSpeciesInfoClick: async () => await onSpeciesInfoClick(api)
    }), infoArea);

    //new Paging(api, "paging-nav").render(speciesInfo);
    const paging = new Paging(api, "paging-nav", async (pageNumber) => await showSpeciesInfoPage(api, pageNumber));
    paging.render(speciesInfo);
}

async function onDeleteParkClick(infoApi) {
    await infoApi.delete();
    window.location.reload();
}

async function showSpeciesInfoPage(api, pageNumber) {
    const data = await api.getSpeciesInfo(pageNumber);
    const area = document.getElementById("species-info-area");
    ReactDOM.render(React.createElement(SpeciesInfo, {
        info: data.items,
        onSpeciesInfoClick: async () => await onSpeciesInfoClick(api)
    }), area);
}