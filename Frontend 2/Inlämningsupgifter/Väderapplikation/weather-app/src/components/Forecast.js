import React, { Component } from "react";

export default class Forecast extends Component {
    constructor(props) {
      super(props)
    
      this.state = {
          forecast: [],
          date: null,
          icon: null,
          city: null,
          sunrise: null,
          sundown: null,
         
      }
    }
    
  componentWillMount() {
    fetch(
      "https://api.openweathermap.org/data/2.5/forecast?q=Stockholm,SE&appid=90f257b3069e625823b544c241fd1c26&units=metric"
    )
      .then(resp => resp.json())
      .then(json =>
        this.setState({            
          forecast: json.list,
          date: json.list.dt,
          icon: json.list[0].weather[0].id,
          city: json.city.name
        })
      );
      console.log(this.state.forecast)
  }
  render() {
    return <div />;
  }
}
