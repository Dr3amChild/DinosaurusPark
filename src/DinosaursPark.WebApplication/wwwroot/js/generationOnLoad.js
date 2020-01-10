const React = window.React;
const ReactDOM = window.ReactDOM;

window.onload = async () => {
    const generation = new Generation(10, 100, 10); //todo replace literals
    generation.showForm();
};