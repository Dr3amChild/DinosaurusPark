const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new ParkInfoApi();
    try {
        const parkInfo = await api.getParkInfo();
        const area = document.getElementById("info-area");
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(React.createElement(ParkInfo, {
            info: parkInfo,
            onSpeciesInfoClick: async () => await onSpeciesInfoClick(api)
        }), area);
    } catch (e) {
        window.location.href = "/generation";
    }
};

async function onSpeciesInfoClick(api) {
    const speciesInfo = await api.getSpeciesInfo();
    const infoArea = document.getElementById("species-info-area");
    ReactDOM.render(React.createElement(SpeciesInfo, {
        info: speciesInfo.items,
        onSpeciesInfoClick: async () => await onSpeciesInfoClick(api)
    }), infoArea);
}