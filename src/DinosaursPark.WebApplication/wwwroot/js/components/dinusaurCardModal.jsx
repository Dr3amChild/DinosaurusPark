class DinosaurModal extends React.Component {
    render() {
        return (
            <Modal header={this.props.modalHeader} 
                   content={this.getContent()}  
                   buttonTitle={this.props.buttonTitle} />
        );
    }

    getContent() {
        return (
            <div>
                <Photo source={this.props.info.image} />
                <Row names={[{ key: "name", "title": "Имя:" }, { key: "age", title: "Возраст, лет:" }]} info={this.props.info} />
                <Row names={[{ key: "gender", "title": "Пол:" }]} info={this.props.info} />
                <Row names={[{ key: "species", "title": "Вид:" }, { key: "foodType", title: "Тип питания:" }]} info={this.props.info} />
                <Row names={[{ key: "height", "title": "Рост, см:" }, { key: "weight", title: "Вес, кг:" }]} info={this.props.info} />
                <Description header="Описание" value={this.props.info.description} />
            </div>
        );
    }
}

class Photo extends React.Component {
    render() {
        return (
            <div id="image-holder">
                <img className="img-thumbnail" src={this.props.source} />
            </div>
        );
    }
}

class Row extends React.Component {
    render() {
        return (
            <div className="row">
                {this.createItems()}
            </div>
        );
    }

    createItems() {
        const items = [];
        for (let name of this.props.names) {
            items.push(<DinosaurField key={name.key} header={name.title} value={this.props.info[name.key]} />);
        }
        return items;
    }
}

class DinosaurField extends React.Component {
    render() {
        return (
            <div className="col-sm">
                <div className="info-header">{this.props.header}</div>
                <p>{this.props.value}</p>
            </div>
        );
    }
}

class Description extends React.Component {
    render() {
        return (
            <div>
                <div className="info-header">{this.props.header}</div>
                <p>{this.props.value}</p>
            </div>
        );
    }
}