const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new ParkInfoApi();    
    try {
        const parkInfo = await api.load();
        const area = document.getElementById("info-area");
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(React.createElement(ParkInfo, { info: parkInfo }), area);
    } catch (e) {
        console.error(e);
    }
    //if (!result || !result.items.length) {
    //    const area = document.getElementById("no-data-alert");
    //    area.style.display = "block";
    //    ReactDOM.unmountComponentAtNode(area);
    //    ReactDOM.render(
    //        React.createElement(GenerationForm,
    //        {
    //            onClick: async () => await onGenerateClick(api),
    //            species: 10,
    //            dinosaurs: 100
    //        }),
    //        area);
    //} else {        
    //}
}
