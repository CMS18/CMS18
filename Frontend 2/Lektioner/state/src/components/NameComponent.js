import React, { Component } from "react";
import NameList from "./NameList.js";

export default class NameComponent extends Component {
  //Det här är standard, något man "bara ska skriva"
  constructor(props) {
    super(props);

    //Eventhandlers som vi behöver när vi gör events efter render()
    this.addName = this.addName.bind(this);
    this.removeName = this.removeName.bind(this);

    //Här lägger vi ett state för namnen vi ska ha i listan. Alltså en array av "names"
    this.state = {
      names: []
    };
  }

  addName() {
    //Old way
    // this.setState({
    //   names: this.state.names.concat(this.newName.value)
    // });

    //Här sätter vi vad names faktiskt är
    this.setState({
      //ES6 way
      names: [...this.state.names, this.newName.value]
    });
  }

  //Här börjar vi med att filtrera våra namn, och när vi klickar på remove knappen
  // så visar vi en ny array med alla namn förutom det som vi rog bort
  removeName() {
    let filterdArray = this.state.names.filter(name => {
      return name !== this.newName.value;
    });
    this.setState({
      names: filterdArray
    });
  }

  render() {
    return (
      <div>
        {/* Här använder vi "ref" för att referera till vår addName funktion */}
        <input type="text" ref={val => (this.newName = val)} />

        {/* onClick är samma sak som vi gjort i DOM manipulation, 
        dvs att när vi klickar så ska vi kalla vår addName funktion */}
        <button onClick={this.addName}>Add name</button>
        <button onClick={this.removeName}>Remove</button>

        {/* Här hämtar vi vår NameList komponent som listar alla namn vi lägger till */}
        <NameList names={this.state.names} />
      </div>
    );
  }
}
