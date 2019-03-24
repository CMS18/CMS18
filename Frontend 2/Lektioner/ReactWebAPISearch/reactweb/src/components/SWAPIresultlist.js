import React, { Component } from "react";

export default class SWAPIresultlist extends Component {
  render() {
    let itemList = this.props.persons.map(person => {
      return <li>{person.name}</li>;
    });

    return <ul>{itemList}</ul>;
  }
}
