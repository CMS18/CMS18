import React, { Component } from "react";
import Weather from "./components/Weather";
import ForecastList from './components/ForecastList'

class App extends Component {
  render() {
    let styles = {
      mainComponent: {
        width: "100vw",
        display: "flex",
        alignItems: "center",
        flexDirection: "column"
      }
    }
    return (
      <div style={styles.mainComponent}>
          <Weather />
          <ForecastList />
      </div>
    );
  }
}

export default App;
