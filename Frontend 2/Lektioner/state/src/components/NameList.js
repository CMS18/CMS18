import React, { Component } from "react";

export default class NameList extends Component {
    //Här skapar vi listan av alla namn som vi lägger till från NameComponents
  render() {
    let allNames = this.props.names.map(name => {
      return <li>{name}</li>;
    });

    return <ul>{allNames}</ul>;
  }
}
