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
                <PreviewRow title="Вид" value={this.props.info.species} valueClass={"species-name"} />
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
        return [
            <div key="1" className="row-header">{this.props.title}</div>,
            <div key="2" className={"row-value " + this.props.valueClass}>{this.props.value}</div>          
        ];
    }
}

class Button extends React.Component {
    render() {
        return (
            <button className="btn btn-info dinusaur-info-btn" onClick={() => this.onLoadInfoClick(this.props.info.id)}>{this.props.title}</button>
        );
    }

    async onLoadInfoClick(id) {
        const info = await new DinosaursApi(10).getById(id); //todo replace with class member
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