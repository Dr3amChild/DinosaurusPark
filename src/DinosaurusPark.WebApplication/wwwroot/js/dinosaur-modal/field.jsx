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