const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const api = new ParkInfoApi();    
    try {
        const parkInfo = await api.getParkInfo();
        const area = document.getElementById("info-area");
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(React.createElement(ParkInfo, { info: parkInfo }), area);
    } catch (e) {
        window.location.href = "/generation";
    }
};
