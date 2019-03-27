import React, { Component } from "react";
import "./App.css";
import BlogList from "./components/BlogList";

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <BlogList />
        </header>
      </div>
    );
  }
}

export default App;
