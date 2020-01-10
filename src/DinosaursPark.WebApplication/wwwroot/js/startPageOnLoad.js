const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const pageSize = 10;
    const api = new DinosaursApi(pageSize);    
    const result = await api.getPage(1);
    if (!result || !result.items.length) {
        window.location.href = "/generation";
    } else {
        const paging = new Paging(api);
        paging.show(result);
        paging.setPaging(result);
    }
};