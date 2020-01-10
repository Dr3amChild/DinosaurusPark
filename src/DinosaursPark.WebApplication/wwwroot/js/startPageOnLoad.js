const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const pageSize = 10;
    const api = new DinosaursApi(pageSize);    
    const result = await api.getPage(1);
    const generation = new Generation(10, 100, pageSize); //todo replace literals
    if (!result || !result.items.length) {
        window.location.href = "/generation";
    } else {
        generation.show(result);
        generation.setPaging(result);
    }
};