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