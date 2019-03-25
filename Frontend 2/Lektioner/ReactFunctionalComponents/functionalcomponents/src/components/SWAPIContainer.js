import React, { Component } from "react";
import PeopleList from "./PeopleList";

export default class SWAPIContainer extends Component {
  constructor(props) {
    super(props);

    this.state = {
      people: []
    };
  }

  componentDidMount() {
    fetch("https://swapi.co/api/people/")
      .then(resp => resp.json())
      .then(json =>
        this.setState({
          people: json.results
        })
      );
  }

  render() {
    return <PeopleList people={this.state.people} />;
  }
}
