import React, { Component } from "react";
import "./App.css";
import NameComponent from "./components/NameComponent";

export default class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <NameComponent />
        </header>
      </div>
    );
  }
}

