const React = window.React;
const ReactDOM = window.ReactDOM;
const redirect = window.Redirect;

window.onload = async () => {
    await new DinosaursApi(Constants.PageSize).getPage(1);
    const generation = new Generation(Constants.InitialSpeciesCount, Constants.InitialDinosaursCount, Constants.PageSize, redirect);
    generation.showForm();
};