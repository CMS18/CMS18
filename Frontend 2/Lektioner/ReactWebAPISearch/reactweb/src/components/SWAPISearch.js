import React, { Component } from "react";
import RL from "./SWAPIresultlist";

export default class SWAPISearch extends Component {
  constructor(props) {
    super(props);

    this.search = this.search.bind(this);
    this.state = { persons: [] };
  }

  async search() {
    let personList = await this.fetchData(this.searchText.value);

    // for(let person of personList.results){}

    this.setState({
      persons: personList.results
    });
  }

  async fetchData(searchtext) {
    let url = "https://swapi.co/api/people/?search=" + searchtext;
    let promise = await fetch(url);

    let data = await promise.json();
    return data;
  }

  render() {
    return (
      <div>
        <input type="text" ref={val => (this.searchText = val)} />
        <button onClick={this.search}>Sök</button>
        <RL persons={this.state.persons} />
      </div>
    );
  }
}
