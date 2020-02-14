const React = window.React;
const ReactDOM = window.ReactDOM;
const redirect = window.Redirect;

window.onload = async () => {
    await new DinosaursApi(10).getPage(1);
    const generation = new Generation(10, 100, 10, redirect);
    generation.showForm();
};