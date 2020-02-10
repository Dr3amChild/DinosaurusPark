const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const pageSize = 10; //todo replace pageSize
    const infoApi = new ParkInfoApi(pageSize);
    try {
        const parkInfo = await infoApi.getParkInfo();
        const area = document.getElementById("info-area");
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(React.createElement(ParkInfo, {
            info: parkInfo,
            onSpeciesInfoClick: async () => await onSpeciesInfoClick(infoApi),
            onDeleteParkClick: async () => await onDeleteParkClick(infoApi, new DinosaursApi(pageSize)),
        }), area);
    } catch (e) {
        window.location.href = "/generation";
    }
};

async function onSpeciesInfoClick(api) {
    const speciesInfo = await api.getSpeciesInfo(1); //todo replace page number
    const infoArea = document.getElementById("species-info-area");
    ReactDOM.render(React.createElement(SpeciesInfo, {
        info: speciesInfo.items,
        onSpeciesInfoClick: async () => await onSpeciesInfoClick(api)
    }), infoArea);
}

async function onDeleteParkClick(infoApi) {
    await infoApi.delete();
    window.location.reload();
}