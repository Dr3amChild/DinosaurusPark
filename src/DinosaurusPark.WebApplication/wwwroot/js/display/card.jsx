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