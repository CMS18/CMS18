import React, { Component } from 'react';
import './App.css';
import SWAPIContainer from './components/SWAPIContainer';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
        <SWAPIContainer />
        </header>
      </div>
    );
  }
}

export default App;
