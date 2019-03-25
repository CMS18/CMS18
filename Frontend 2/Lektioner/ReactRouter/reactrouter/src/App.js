import React, { Component } from "react";
import "./App.css";
import Navigation from './components/Navigation'
import Main from './components/Main'


class App extends Component {
  render() {
    return (
      <div className="app">
      <Navigation />
      <Main />
      </div>
    );
  }
}

export default App;
