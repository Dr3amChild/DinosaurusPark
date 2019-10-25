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