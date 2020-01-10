const React = window.React;
const ReactDOM = window.ReactDOM;
const redirect = window.Redirect;

window.onload = async () => {
    const generation = new Generation(10, 100, 10, redirect);
    generation.showForm();
};