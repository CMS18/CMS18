import React, { Component } from "react";
import "./App.css";
import Weather from "./components/Weather";
import Forecast from "./components/Forecast";

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <Weather />
          <Forecast />
        </header>
      </div>
    );
  }
}

export default App;
