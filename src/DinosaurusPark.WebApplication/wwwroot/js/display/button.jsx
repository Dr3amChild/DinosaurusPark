class Button extends React.Component {
    render() {
        return (
            <button className="btn btn-info dinusaur-info-btn" onClick={() => this.onLoadInfoClick(this.props.info.id)}>{this.props.title}</button>
        );
    }

    async onLoadInfoClick(id) {
        const info = await loadById(id);
        ReactDOM.render(React.createElement(DinosaurModal,
            {
                modalHeader: "Подробная информация",
                buttonTitle: "Закрыть",
                info
            }),
            document.getElementById("dinosaur-modal"));
        $("#dinosaur-modal").modal();
    }
}