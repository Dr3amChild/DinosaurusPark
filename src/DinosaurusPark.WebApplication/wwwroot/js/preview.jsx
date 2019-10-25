class Cards extends React.Component {
    render() {
        const cards = [];
        for (let item of this.props.items) {
            cards.push(<Card key={item.id} info={item} />);
        }
        return cards;
    }
}

class Card extends React.Component {
    render() {
        return (
            <div className="dinosaur-card alert alert-info">
                <Preview image={this.props.info.image} />
                <PreviewRow title="Динозавр" value={this.props.info.name} />
                <PreviewRow title="Вид" value={this.props.info.species} />
                <Button title="Подробнее" info={this.props.info} />
            </div>
        );
    }
}

class Preview extends React.Component {
    render() {
        return (
            <img className='dinosaur-photo' src={this.props.image} />
        );
    }
}

class PreviewRow extends React.Component {
    render() {
        return (
            <div>
                <div className="row-header">{this.props.title}</div>
                <div className="row-value">{this.props.value}</div>
            </div>
        );
    }
}

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