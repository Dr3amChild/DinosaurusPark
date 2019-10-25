class Photo extends React.Component {
    render() {
        return (
            <div id="image-holder">
                <img className="img-thumbnail" src={this.props.source} />
            </div>
        );
    }
}