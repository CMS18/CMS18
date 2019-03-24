import React, { Component } from "react";
import "./App.css";
import SWAPISearch from './components/SWAPISearch'

export default class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <SWAPISearch />
        </header>
      </div>
    );
  }
}
